using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.CorDbg;
using ClrMd.Model;
using ClrMd.ViewModel;

namespace ClrMd.Abstractions {
	public interface IDebuggerOperations {
		/// <summary>
		/// Attaches to process.
		/// </summary>
		/// <param name="item">The item.</param>
		void AttachToProcess(object item);

		/// <summary>
		/// Refreshes the process list.
		/// </summary>
		/// <param name="viewModel">The view model.</param>
		void RefreshProcessList(RunningProcessVm viewModel);

		/// <summary>
		/// Gets the dump.
		/// </summary>
		/// <returns>ObservableCollection&lt;HeapDump&gt;.</returns>
		ObservableCollection<HeapDump> GetHeapDump();

		/// <summary>
		/// Gets the heap stats.
		/// </summary>
		/// <returns>ObservableCollection&lt;HeapDumpStat&gt;.</returns>
		ObservableCollection<HeapDumpStat> GetHeapStats();
			
		/// <summary>
		/// Gets the session.
		/// </summary>
		/// <value>The session.</value>
		DebugSession Session { get; }

		/// <summary>
		/// Ges the threads and stack trace.
		/// </summary>
		/// <returns>ObservableCollection&lt;Thread&gt;.</returns>
		ObservableCollection<Thread> GeThreadsAndStackTrace();
	}
}
