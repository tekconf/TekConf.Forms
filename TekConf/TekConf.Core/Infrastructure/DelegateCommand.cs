using System;
using System.Windows.Input;
using System.Threading.Tasks;

namespace TekConf.Core
{
	public sealed class DelegateCommand : ICommand
	{
		readonly Action<object> command;
		readonly Func<object, bool> canExecute;

		public event EventHandler CanExecuteChanged = delegate { };

		public DelegateCommand (Action<object> command) : this (command, null)
		{
		}

		public DelegateCommand (Action command) : this (command, null)
		{
		}

		public DelegateCommand (Action command, Func<bool> test)
		{
			if (command == null)
				throw new ArgumentNullException ("command", "Command cannot be null.");
			this.command = delegate {
				command ();
			};
			if (test != null) {
				this.canExecute = delegate {
					return test ();
				};
			}
		}

		public DelegateCommand (Action<object> command, Func<object, bool> test)
		{
			if (command == null)
				throw new ArgumentNullException ("command", "Command cannot be null.");

			this.command = command;
			this.canExecute = test;
			;
		}

		public void RaiseCanExecuteChanged ()
		{
			this.CanExecuteChanged (this, EventArgs.Empty);
		}

		public bool CanExecute (object parameter)
		{
			return (this.canExecute == null) || this.canExecute (parameter);
		}

		public void Execute (object parameter)
		{
			this.command (parameter);
		}
	}

	public sealed class DelegateCommand<T> : ICommand
	{
		readonly Action<T> command;
		readonly Func<T, bool> canExecute;

		public event EventHandler CanExecuteChanged = delegate { };

		public DelegateCommand (Action<T> command) : this (command, null)
		{
		}

		public DelegateCommand (Action<T> command, Func<T, bool> test)
		{
			if (command == null)
				throw new ArgumentNullException ("command", "Command cannot be null.");

			this.command = command;
			this.canExecute = test;
		}

		public void RaiseCanExecuteChanged ()
		{
			this.CanExecuteChanged (this, EventArgs.Empty);
		}

		public bool CanExecute (object parameter)
		{
			return (this.canExecute == null) || this.canExecute ((T)parameter);
		}

		public void Execute (object parameter)
		{
			this.command ((T)parameter);
		}
	}
		
	public class AsyncDelegateCommand : ICommand
	{
		protected readonly Predicate<object> _canExecute;
		protected Func<object, Task> _asyncExecute;

		public event EventHandler CanExecuteChanged = delegate { };

		public AsyncDelegateCommand(Func<object, Task> execute)
			: this(execute, null)
		{
		}

		public AsyncDelegateCommand(Func<object, Task> asyncExecute,
			Predicate<object> canExecute)
		{
			_asyncExecute = asyncExecute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute == null)
			{
				return true;
			}

			return _canExecute(parameter);
		}

		public async void Execute(object parameter)
		{
			await ExecuteAsync(parameter);
		}

		public async Task ExecuteAsync(object parameter)
		{
			await _asyncExecute(parameter);
		}
	}

	public class AsyncDelegateCommand<T> : ICommand
	{
		protected readonly Predicate<T> _canExecute;
		protected Func<T, Task> _asyncExecute;

		public event EventHandler CanExecuteChanged = delegate { };

		public AsyncDelegateCommand(Func<T, Task> execute)
			: this(execute, null)
		{
		}

		public AsyncDelegateCommand(Func<T, Task> asyncExecute,
			Predicate<T> canExecute)
		{
			_asyncExecute = asyncExecute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return (_canExecute == null) || _canExecute((T)parameter);
		}

		public async void Execute(object parameter)
		{
			await ExecuteAsync((T)parameter);
		}

		public async Task ExecuteAsync(T parameter)
		{
			await _asyncExecute(parameter);
		}
	}

}