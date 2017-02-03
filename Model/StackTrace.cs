using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	public class StackTrace : BaseModel {
		/// <summary>
		/// The instruction PTR
		/// </summary>
		private string instructionPtr;

		/// <summary>
		/// The stack PTR
		/// </summary>
		private string stackPtr;

		/// <summary>
		/// The method
		/// </summary>
		private string method;

		/// <summary>
		/// Gets or sets the instruction PTR.
		/// </summary>
		/// <value>The instruction PTR.</value>
		public string InstructionPtr {
			get {
				return instructionPtr;
			}
			set {
				instructionPtr = value;
				OnPropertyChanged("InstructionPtr");
			}
		}

		/// <summary>
		/// Gets or sets the stack PTR.
		/// </summary>
		/// <value>The stack PTR.</value>
		public string StackPtr {
			get {
				return stackPtr;
			}
			set {
				stackPtr = value;
				OnPropertyChanged("StackPtr");
			}
		}

		/// <summary>
		/// Gets or sets the method.
		/// </summary>
		/// <value>The method.</value>
		public string Method {
			get {
				return method;
			}
			set {
				method = value;
				OnPropertyChanged("Method");
			}
		}

	}
}
