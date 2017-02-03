using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	public class HeapDumpStat : BaseModel {
		/// <summary>
		/// The count
		/// </summary>
		private int count;

		/// <summary>
		/// The size
		/// </summary>
		private long size;

		/// <summary>
		/// The type name
		/// </summary>
		private string typeName;

		/// <summary>
		/// Gets or sets the count.
		/// </summary>
		/// <value>The count.</value>
		public int Count {
			get {
				return count;
			}
			set {
				count = value;
				OnPropertyChanged("Count");
			}
		}


		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public long Size {
			get {
				return size;
			}
			set {
				size = value;
				OnPropertyChanged("Size");
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
