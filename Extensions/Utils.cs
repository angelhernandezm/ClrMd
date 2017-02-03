using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.ViewModel;
using Microsoft.Diagnostics.Runtime;

namespace ClrMd.Extensions {
	public static class Utils {
		/// <summary>
		/// Determines whether [is attach option valid] [the specified instance].
		/// </summary>
		/// <param name="instance">The instance.</param>
		/// <returns><c>true</c> if [is attach option valid] [the specified instance]; otherwise, <c>false</c>.</returns>
		public static bool IsAttachOptionValid(this AttachmentOptionVm instance) {
			var retval = false;

			retval = instance != null && (!string.IsNullOrEmpty(instance.AttachFlag) && instance.MilliSeconds > 0);

			return retval;
		}

	}
}
