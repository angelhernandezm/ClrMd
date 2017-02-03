using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClrMd.Model {
	/// <summary>
	/// Class RunningProcess.
	/// </summary>
	public class RunningProcess : BaseModel {
		/// <summary>
		/// The process identifier
		/// </summary>
		private int processId;
		/// <summary>
		/// The image path
		/// </summary>
		private string imagePath;
		/// <summary>
		/// The process name
		/// </summary>
		private string processName;
		/// <summary>
		/// The icon
		/// </summary>
		private ImageSource icon;

		/// <summary>
		/// Gets or sets the process identifier.
		/// </summary>
		/// <value>The process identifier.</value>
		public int ProcessId {
			get {
				return processId;
			}
			set {
				processId = value;
				OnPropertyChanged("ProcessId");
			}
		}

		/// <summary>
		/// Gets or sets the image path.
		/// </summary>
		/// <value>The image path.</value>
		public string ImagePath {
			get {
				return imagePath;
			}
			set {
				imagePath = value;
				OnPropertyChanged("ImagePath");
			}
		}

		/// <summary>
		/// Gets or sets the name of the process.
		/// </summary>
		/// <value>The name of the process.</value>
		public string ProcessName {
			get {
				return processName;
			}
			set {
				processName = value;
				OnPropertyChanged("ProcessName");
			}
		}

		/// <summary>
		/// Gets or sets the icon.
		/// </summary>
		/// <value>The icon.</value>
		public ImageSource Icon {
			get {
				return icon;
			}
			set {
				icon = value;
				OnPropertyChanged("Icon");
			}
		}
	}
}
