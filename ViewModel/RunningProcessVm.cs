using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ClrMd.Command;
using ClrMd.CorDbg;
using ClrMd.Model;

namespace ClrMd.ViewModel {
	/// <summary>
	/// Class RunningProcessVm.
	/// </summary>
	public class RunningProcessVm: BaseViewModel<RunningProcess> {
		/// <summary>
		/// Gets or sets a value indicating whether this instance can execute.
		/// </summary>
		/// <value><c>true</c> if this instance can execute; otherwise, <c>false</c>.</value>
		protected bool CanExecute {
			get;
			set;
		}

		/// <summary>
		/// Gets the attachment option.
		/// </summary>
		/// <value>The attachment option.</value>
		public AttachmentOptionVm AttachmentOption {
			get;
			private set;
		}


		/// <summary>
		/// Gets the attach to process command.
		/// </summary>
		/// <value>The attach to process command.</value>
		public ICommand AttachToProcessCommand {
			get;
			private set;
		}

		/// <summary>
		/// Gets the refresh processes command.
		/// </summary>
		/// <value>The refresh processes command.</value>
		public ICommand RefreshProcessesCommand {
			get;
			private set;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RunningProcessVm"/> class.
		/// </summary>
		public RunningProcessVm() {
			CanExecute = true;
			AttachmentOption = new AttachmentOptionVm();
			RefreshProcessesCommand = new ButtonCommand(() => Debugger.RefreshProcessList(this), true);
			AttachToProcessCommand = new ButtonCommand(z => Debugger.AttachToProcess(z), AttachmentOption, true);
			GetRunningProcesses();
		}

		/// <summary>
		/// Gets the running processes.
		/// </summary>
		public void GetRunningProcesses() {
			Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => {
				Data.Clear();
				foreach (var process in Process.GetProcesses()) {
					try {
						Data.Add(new RunningProcess() {
							ProcessId = process.Id,
							ProcessName = process.ProcessName,
							ImagePath = process.MainModule.FileName,
							Icon = (new Func<string, ImageSource>(s => {
								ImageSource retval = null;

								using (var hIcon = Icon.ExtractAssociatedIcon(s))
									retval = Imaging.CreateBitmapSourceFromHIcon(hIcon.Handle,
										Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

								return retval;
							})).Invoke(process.MainModule.FileName)


						});
					} catch (Exception) {

					}
				}

			}));




		}
	}
}