using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.Model;

namespace ClrMd.ViewModel {
	public class HeapDumpStatVm : BaseViewModel<HeapDumpStat> {
		/// <summary>
		/// Initializes a new instance of the <see cref="HeapDumpStatVm"/> class.
		/// </summary>
		public HeapDumpStatVm() {
			Data = Debugger.GetHeapStats();
		}
	}
}
