using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClrMd.Command;
using ClrMd.Model;
using ClrMd.View;

namespace ClrMd.ViewModel {
	public class DebuggerOptionVm : BaseViewModel<DebuggerOption> {
		/// <summary>
		/// The selected option
		/// </summary>
		private DebuggerOption selectedOption = new DebuggerOption();

		/// <summary>
		/// Gets or sets a value indicating whether this instance can execute.
		/// </summary>
		/// <value><c>true</c> if this instance can execute; otherwise, <c>false</c>.</value>
		protected bool CanExecute {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the selected option.
		/// </summary>
		/// <value>The selected option.</value>
		public DebuggerOption SelectedOption {
			get {
				return selectedOption;
			}
			set {
				selectedOption = value;
			}
		}

		/// <summary>
		/// Gets the run debugger command.
		/// </summary>
		/// <value>The run debugger command.</value>
		public ICommand RunDebuggerCommand {
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebuggerOptionVm"/> class.
		/// </summary>
		public DebuggerOptionVm() {
			CanExecute = true;
			RunDebuggerCommand = new ButtonCommand(() => ManageSelectedView(SelectedOption), true);
			LoadOptions();
		}

		/// <summary>
		/// Loads the options.
		/// </summary>
		protected void LoadOptions() {
			Data.Add(new DebuggerOption() {
				Description = "Dump Heap", Option = 1, SelectedViewType = typeof(HeapDumpView)
			});

			Data.Add(new DebuggerOption() {
				Description = "Heap Stats", Option = 2, SelectedViewType = typeof(HeapStatView)
			});

			Data.Add(new DebuggerOption() {
				Description = "Threads and StackTrace", Option = 3, SelectedViewType = typeof(ThreadStackView)
			});



		}

	}
}
