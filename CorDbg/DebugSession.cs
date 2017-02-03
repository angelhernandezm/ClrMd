using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Runtime;

namespace ClrMd.CorDbg {
	public class DebugSession : IDisposable {
		/// <summary>
		/// The is disposed
		/// </summary>
		private bool isDisposed = false;

		/// <summary>
		/// Gets the attached target.
		/// </summary>
		/// <value>The attached target.</value>
		public DataTarget AttachedTarget {
			get;
			private set;
		}

		/// <summary>
		/// Gets the runtime.
		/// </summary>
		/// <value>The runtime.</value>
		public ClrRuntime Runtime {
			get;
			private set;
		}

		/// <summary>
		/// Gets a value indicating whether this instance is attached.
		/// </summary>
		/// <value><c>true</c> if this instance is attached; otherwise, <c>false</c>.</value>
		public bool IsAttached {
			get { return AttachedTarget != null && AttachedTarget.EnumerateModules().Any(); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugSession"/> class.
		/// </summary>
		/// <param name="target">The target.</param>
		public DebugSession(DataTarget target)
			: this() {

			if (target == null)
				throw new NullReferenceException("DataTarget can't be null");

			AttachedTarget = target;
			Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugSession"/> class.
		/// </summary>
		/// <param name="processId">The process identifier.</param>
		/// <param name="milliSeconds">The milli seconds.</param>
		/// <param name="flag">The flag.</param>
		public DebugSession(int processId, uint milliSeconds, AttachFlag flag)
			: this() {

			AttachedTarget = DataTarget.AttachToProcess(processId, milliSeconds, flag);
			Initialize();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugSession"/> class.
		/// </summary>
		protected DebugSession() {

		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		protected void Initialize() {
			if (AttachedTarget != null && AttachedTarget.ClrVersions != null) {
				var dacLocation = AttachedTarget.ClrVersions.FirstOrDefault().TryGetDacLocation();
				Runtime = AttachedTarget.CreateRuntime(dacLocation);


			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool isDisposing) {
			if (!isDisposed) {
				if (isDisposing) {
					if (AttachedTarget != null)
						AttachedTarget.Dispose();
				}
				isDisposed = true;
			}

		}

		/// <summary>
		/// Finalizes an instance of the <see cref="DebugSession"/> class.
		/// </summary>
		~DebugSession() {
			Dispose(false);
		}
	}
}