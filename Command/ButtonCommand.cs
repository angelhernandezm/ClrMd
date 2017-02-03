using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClrMd.Model;
using ClrMd.ViewModel;

namespace ClrMd.Command {
	/// <summary>
	/// Class ButtonCommand.
	/// </summary>
	public class ButtonCommand : ICommand {
		/// <summary>
		/// The action
		/// </summary>
		private readonly Action action;
		/// <summary>
		/// The can execute
		/// </summary>
		private readonly bool canExecute;

		/// <summary>
		/// The action with argument
		/// </summary>
		private readonly Action<object> actionWithArg;

		/// <summary>
		/// The option
		/// </summary>
		private readonly AttachmentOptionVm option;

		//TODO: Pass functor to validate whether command can execute - Method in viewmodel

		/// <summary>
		/// The check if can execute functor
		/// </summary>
		private Func<string, bool> checkIfCanExecuteFunctor; 

		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonCommand" /> class.
		/// </summary>
		/// <param name="action">The _action.</param>
		/// <param name="canExecute">if set to <c>true</c> [_can execute].</param>
		public ButtonCommand(Action action, bool canExecute) {
			this.action = action;
			this.canExecute = canExecute;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonCommand" /> class.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="option">The option.</param>
		/// <param name="canExecute">if set to <c>true</c> [can execute].</param>
		public ButtonCommand(Action<object> action, AttachmentOptionVm option, bool canExecute) {
			this.option = option;
			this.actionWithArg = action;
			this.canExecute = canExecute;
		}

		/// <summary>
		/// Defines the method that determines whether the command can execute in its current state.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
		/// <returns>true if this command can be executed; otherwise, false.</returns>
		public bool CanExecute(object parameter) {
			return canExecute;
		}

		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute.
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Defines the method to be called when the command is invoked.
		/// </summary>
		/// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
		public void Execute(object parameter) {
			if (action != null)
				action();
			else if (parameter != null && option != null)
				actionWithArg(new object[] {parameter, option});
		}
	}
}
