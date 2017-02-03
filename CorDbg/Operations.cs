using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ClrMd.Abstractions;
using ClrMd.Extensions;
using ClrMd.Model;
using ClrMd.ViewModel;
using Diag = Microsoft.Diagnostics.Runtime;

namespace ClrMd.CorDbg {
	/// <summary>
	/// Class Operations.
	/// </summary>
	public class Operations : IDebuggerOperations {
		/// <summary>
		/// The synchronize
		/// </summary>
		private static readonly object sync = new object();
		/// <summary>
		/// The singleton
		/// </summary>
		private static volatile Operations singleton;

		/// <summary>
		/// Gets the current.
		/// </summary>
		/// <value>The current.</value>
		public static IDebuggerOperations Current {
			get {
				lock (sync) {
					if (singleton == null)
						singleton = new Operations();
				}
				return singleton;
			}

		}

		/// <summary>
		/// Gets a value indicating whether this instance is attached.
		/// </summary>
		/// <value><c>true</c> if this instance is attached; otherwise, <c>false</c>.</value>
		public bool IsAttached {
			get {
				return Session.IsAttached;
			}
		}


		/// <summary>
		/// Gets the session.
		/// </summary>
		/// <value>The session.</value>
		public DebugSession Session {
			get;
			private set;
		}

		/// <summary>
		/// Prevents a default instance of the <see cref="Operations"/> class from being created.
		/// </summary>
		private Operations() {

		}

		/// <summary>
		/// Attaches to process.
		/// </summary>
		public void AttachToProcess(object item) {
			Diag.AttachFlag tryParse;
			var selected = ((object[])item)[0] as RunningProcess;
			var option = ((object[])item)[1] as AttachmentOptionVm;

			if (selected != null && option.IsAttachOptionValid() && Enum.TryParse(option.AttachFlag, out tryParse)) {
				Session = new DebugSession(selected.ProcessId, option.MilliSeconds, tryParse);
			}

		}

		/// <summary>
		/// Refreshes the process list.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		public void RefreshProcessList(RunningProcessVm viewModel) {
			viewModel.GetRunningProcesses();

		}

		/// <summary>
		/// Gets the heap stats.
		/// </summary>
		/// <returns>ObservableCollection&lt;HeapDumpStat&gt;.</returns>
		public ObservableCollection<HeapDumpStat> GetHeapStats() {
			var retval = new ObservableCollection<HeapDumpStat>();

			if (Session != null) {

				var heap = Session.Runtime.GetHeap();

				var stats = from x in heap.EnumerateObjects()
							let t = heap.GetObjectType(x)
							group x by t into z
							let size = z.Sum(p => (uint)z.Key.GetSize(p))
							orderby size
							select new {
								TypeName = z.Key.Name,
								Size = size,
								Count = z.Count()
							};

				if (stats.Any())
					stats.ToList().ForEach(x => retval.Add(new HeapDumpStat() {
						TypeName = x.TypeName, Count = x.Count, Size = x.Size
					}));
			}

			return retval;
		}


		/// <summary>
		/// Gets the dump.
		/// </summary>
		/// <returns>ObservableCollection&lt;HeapDump&gt;.</returns>
		public ObservableCollection<HeapDump> GetHeapDump() {
			var retval = new ObservableCollection<HeapDump>();

			if (Session != null) {
				var heap = Session.Runtime.GetHeap();

				heap.EnumerateObjects().ToList().ForEach(x => retval.Add(new HeapDump() {
					TypeName = heap.GetObjectType(x).Name,
					Size = heap.GetObjectType(x).GetSize(x),
					AllocationAddress = string.Format("{0,12:X}", x).Trim()
				}));
			}

			return retval;
		}


		/// <summary>
		/// Ges the threads and stack trace.
		/// </summary>
		/// <returns>ObservableCollection&lt;Thread&gt;.</returns>
		public ObservableCollection<Thread> GeThreadsAndStackTrace() {
			var retval = new ObservableCollection<Thread>();

			if (Session != null) {
				Session.Runtime.Threads.ToList().ForEach(x => {
					var newItem = new Thread() {
						ThreadId = string.Format("{0:X}", x.OSThreadId).Trim(),
						ThreadExecutionBlock = string.Format("{0:X}", x.Teb).Trim()
					};

					x.StackTrace.ToList().ForEach(z => newItem.StackTrace.Add(new StackTrace() {
						InstructionPtr = string.Format("{0,12:X}", z.InstructionPointer),
						StackPtr = string.Format("{0,12:X}", z.StackPointer),
						Method =  (z.Method != null ?  z.Method.GetFullSignature() : string.Empty)
					}));

					retval.Add(newItem);
				});
			}

			return retval;

		}
	}
}
