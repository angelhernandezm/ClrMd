using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.CorDbg;
using ClrMd.Model;
using Microsoft.Diagnostics.Runtime;

namespace ClrMd.ViewModel {
	/// <summary>
	/// Class HeapDumpVm.
	/// </summary>
	public class HeapDumpVm : BaseViewModel<HeapDump> {
		/// <summary>
		/// Initializes a new instance of the <see cref="HeapDumpVm"/> class.
		/// </summary>
		public HeapDumpVm() {
			Data = Debugger.GetHeapDump();
		}
	}
}
