using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	/// <summary>
	/// Class HeapDump.
	/// </summary>
	public class HeapDump : BaseModel {
		/// <summary>
		/// The size
		/// </summary>
		private ulong size;

		/// <summary>
		/// The type name
		/// </summary>
		private string typeName;

		/// <summary>
		/// The allocation address
		/// </summary>
		private string allocationAddress;


		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public ulong Size {
			get {
				return size;
			}
			set {
				size = value;
				OnPropertyChanged("Size");
			}

		}

		/// <summary>
		/// Gets or sets the allocation address.
		/// </summary>
		/// <value>The allocation address.</value>
		public string AllocationAddress {
			get {
				return allocationAddress;
			}
			set {
				allocationAddress = value;
				OnPropertyChanged("AllocationAddress");
			}
		}

		/// <summary>
		/// Gets or sets the name of the type.
		/// </summary>
		/// <value>The name of the type.</value>
		public string TypeName {
			get {
				return typeName;
			}
			set {
				typeName = value;
				OnPropertyChanged("TypeName");
			}
		}
	}
}
