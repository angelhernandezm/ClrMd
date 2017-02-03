using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	public class DebuggerOption : BaseModel {
		/// <summary>
		/// The option
		/// </summary>
		private int option;

		/// <summary>
		/// The description
		/// </summary>
		private string description;

		/// <summary>
		/// The selected view type
		/// </summary>
		private Type selectedViewType;

		/// <summary>
		/// Gets or sets the option.
		/// </summary>
		/// <value>The option.</value>
		public int Option {
			get {
				return option;
			}
			set {
				option = value;
				OnPropertyChanged("Option");
			}
		}

		/// <summary>
		/// Gets or sets the type of the selected view.
		/// </summary>
		/// <value>The type of the selected view.</value>
		public Type SelectedViewType {
			get {
				return selectedViewType;
			}
			set {
				selectedViewType = value;
				OnPropertyChanged("SelectedViewType");
			}

		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description {
			get {
				return description;
			}
			set {
				description = value;
				OnPropertyChanged("Description");
			}
		}
	}
}
