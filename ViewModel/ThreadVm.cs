using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.Model;

namespace ClrMd.ViewModel {
	public class ThreadVm : BaseViewModel<Thread> {
		/// <summary>
		/// Initializes a new instance of the <see cref="ThreadVm"/> class.
		/// </summary>
		public ThreadVm() {
			Data = Debugger.GeThreadsAndStackTrace();
		}
	}
}
