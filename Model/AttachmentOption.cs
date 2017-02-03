using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	public class AttachmentOption : BaseModel {
		/// <summary>
		/// The miliseconds
		/// </summary>
		private uint milliseconds;

		/// <summary>
		/// The attach flag
		/// </summary>
		private string attachFlag;

		/// <summary>
		/// Gets or sets the milli seconds.
		/// </summary>
		/// <value>The milli seconds.</value>
		public uint MilliSeconds {
			get {
				return milliseconds;
			}
			set {
				milliseconds = value;
				OnPropertyChanged("MilliSeconds");
			}
		}

		/// <summary>
		/// Gets or sets the attach flag.
		/// </summary>
		/// <value>The attach flag.</value>
		public string AttachFlag {
			get {
				return attachFlag;
			}
			set {
				attachFlag = value;
				OnPropertyChanged("AttachFlag");
			}
		}
	}
}
