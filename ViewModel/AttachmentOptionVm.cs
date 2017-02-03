using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClrMd.Model;
using Diag = Microsoft.Diagnostics.Runtime;

namespace ClrMd.ViewModel {
	public class AttachmentOptionVm:BaseViewModel<string> {
		/// <summary>
		/// The model
		/// </summary>
		private AttachmentOption model = new AttachmentOption();

		/// <summary>
		/// Gets or sets the milli seconds.
		/// </summary>
		/// <value>The milli seconds.</value>
		public uint MilliSeconds {
			get {
				return model.MilliSeconds;
			}
			set {
				model.MilliSeconds = value;
			}
		}

		/// <summary>
		/// Gets or sets the attach flag.
		/// </summary>
		/// <value>The attach flag.</value>
		public string AttachFlag {
			get {
				return model.AttachFlag;
			}
			set {
				model.AttachFlag = value;
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="AttachmentOptionVm"/> class.
		/// </summary>
		public AttachmentOptionVm() {
			Data = new ObservableCollection<string>(new[] {
				Diag.AttachFlag.Invasive.ToString(),
				Diag.AttachFlag.NonInvasive.ToString(), 
				Diag.AttachFlag.Passive.ToString()
			});
		}
	}
}
