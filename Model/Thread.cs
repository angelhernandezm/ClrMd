using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClrMd.Model {
	public class Thread : BaseModel {
		/// <summary>
		/// The thread identifier
		/// </summary>
		private string threadId;

		/// <summary>
		/// The thread execution block
		/// </summary>
		private string threadExecutionBlock;

		/// <summary>
		/// The stack trace
		/// </summary>
		private ObservableCollection<StackTrace> stackTrace;

		/// <summary>
		/// Gets or sets the thread identifier.
		/// </summary>
		/// <value>The thread identifier.</value>
		public string ThreadId {
			get {
				return threadId;
			}
			set {
				threadId = value;
				OnPropertyChanged("ThreadId");
			}
		}

		/// <summary>
		/// Gets or sets the thread execution block.
		/// </summary>
		/// <value>The thread execution block.</value>
		public string ThreadExecutionBlock {
			get {
				return threadExecutionBlock;
			}
			set {
				threadExecutionBlock = value;
				OnPropertyChanged("ThreadExecutionBlock");
			}
		}

		/// <summary>
		/// Gets or sets the stack trace.
		/// </summary>
		/// <value>The stack trace.</value>
		public ObservableCollection<StackTrace> StackTrace {
			get {
				return stackTrace;
			}
			private set {
				stackTrace = value;
				OnPropertyChanged("StackTrace");
			}

		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Thread"/> class.
		/// </summary>
		public Thread() {
			StackTrace = new ObservableCollection<StackTrace>();
		}

	}
}

