using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClrMd.Abstractions;
using ClrMd.CorDbg;
using ClrMd.Model;

namespace ClrMd.ViewModel {
	/// <summary>
	/// Class BaseViewModel.
	/// </summary>
	public class BaseViewModel<T> {
		/// <summary>
		/// Gets the debugger.
		/// </summary>
		/// <value>The debugger.</value>
		public IDebuggerOperations Debugger {
			get;
			private set;
		}

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public ObservableCollection<T> Data {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseViewModel"/> class.
		/// </summary>
		public BaseViewModel() {
			Data = new ObservableCollection<T>();
			Debugger = Operations.Current;
		}

		/// <summary>
		/// Manages the selected view.
		/// </summary>
		/// <typeparam name="V"></typeparam>
		/// <param name="v">The v.</param>
		protected void ManageSelectedView<V>(V v) {
			var selectedOption = v as DebuggerOption;

			if (selectedOption != null) {
				var existing = Application.Current.MainWindow.OwnedWindows
						.Cast<Window>().FirstOrDefault(x => string.Equals(x.GetType().FullName,
							selectedOption.SelectedViewType.FullName, StringComparison.OrdinalIgnoreCase));

				if (existing != null)
					existing.Activate();
				else {
					var ctor = selectedOption.SelectedViewType.GetConstructor(Type.EmptyTypes);
					var view = ctor.Invoke(null) as Window;

					if (view != null) {
						view.Owner = Application.Current.MainWindow;
						view.Show();
					}
				}
			}
		}

	}
}
