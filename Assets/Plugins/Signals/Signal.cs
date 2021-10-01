using System;
using System.Collections.Generic;

namespace Signals
{
	public class Signal
	{
		private Action _fastInvocationListener;
		private List<Action> _listeners;

		private int _executionCount = 0;
		private bool _didRemoveFromList;
		
		public void Dispatch ()
		{
			_executionCount++;
			
			var countBeforeExecution = (_listeners != null) ? _listeners.Count : 0;
			
			if (_fastInvocationListener != null)
			{
				_fastInvocationListener();
			}
			
			if (_listeners != null)
			{
				for (var i = 0; i < countBeforeExecution; i++)
				{
					var listener = _listeners[ i ];
					if (listener != null)
					{
						listener();
					}
				}
			}

			_executionCount--;
			
			if (_executionCount == 0 && _didRemoveFromList)
			{
				if (_listeners != null)
				{
					_listeners.RemoveAll( c => c == null );
				}
				_didRemoveFromList = false;

			}
		}

		public void AddListener (Action callback)
		{
			if (_fastInvocationListener == null) {
				_fastInvocationListener = callback;
				return;
			}

			if (_fastInvocationListener == callback)
			{
				return;
			}
			
			if (_listeners == null)
			{
				_listeners = new List<Action>();
			}
			
			if (!_listeners.Contains(callback)) {
				_listeners.Add(callback);
			}
		}
		
		public void RemoveListener (Action callback)
		{
			if (_fastInvocationListener == callback)
			{
				_fastInvocationListener = null;
			}
			else if (_listeners != null)
			{
				var index =_listeners.IndexOf(callback);
				if (index != -1)
				{
					_listeners[ index ] = null;
					_didRemoveFromList = true;
				}
			}
		}

		public void RemoveAllListeners ()
		{
			_fastInvocationListener = null;
			if (_listeners != null)
			{
				for (int index = 0; index < _listeners.Count; index++)
				{
					_listeners[ index ] = null;
					_didRemoveFromList = true;
				}
			}
		}
	}
	
	public class Signal<T0>
	{
		private Action<T0> _fastInvocationListener;
		private List<Action<T0>> _listeners;

		private int _executionCount = 0;
		private bool _didRemoveFromList;
		
		public void Dispatch (T0 t0)
		{
			_executionCount++;
			
			var countBeforeExecution = (_listeners != null) ? _listeners.Count : 0;
			
			if (_fastInvocationListener != null)
			{
				_fastInvocationListener( t0 );
			}
			
			if (_listeners != null)
			{
				for (var i = 0; i < countBeforeExecution; i++)
				{
					var listener = _listeners[ i ];
					if (listener != null)
					{
						listener( t0 );
					}
				}
			}

			_executionCount--;
			
			if (_executionCount == 0 && _didRemoveFromList)
			{
				if (_listeners != null)
				{
					_listeners.RemoveAll( c => c == null );
				}
				_didRemoveFromList = false;
			}
		}

		public void AddListener (Action<T0> callback)
		{
			if (_fastInvocationListener == null) {
				_fastInvocationListener = callback;
				return;
			}

			if (_fastInvocationListener == callback)
			{
				return;
			}
			
			if (_listeners == null)
			{
				_listeners = new List<Action<T0>>();
			}
			
			if (!_listeners.Contains(callback)) {
				_listeners.Add(callback);
			}
		}
		
		public void RemoveListener (Action<T0> callback)
		{
			if (_fastInvocationListener == callback)
			{
				_fastInvocationListener = null;
			}
			else if (_listeners != null)
			{
				var index =_listeners.IndexOf(callback);
				if (index != -1)
				{
					_listeners[ index ] = null;
					_didRemoveFromList = true;
				}
			}
		}

		public void RemoveAllListeners ()
		{
			_fastInvocationListener = null;
			if (_listeners != null)
			{
				_listeners.Clear();
				_didRemoveFromList = true;
			}
		}
	}
	
	public class Signal<T0,T1>
	{
		private Action<T0,T1> _fastInvocationListener;
		private List<Action<T0,T1>> _listeners;

		private int _executionCount = 0;
		private bool _didRemoveFromList;
		
		public void Dispatch (T0 t0, T1 t1)
		{
			_executionCount++;
			
			var countBeforeExecution = (_listeners != null) ? _listeners.Count : 0;
			
			if (_fastInvocationListener != null)
			{
				_fastInvocationListener( t0, t1 );
			}
			
			if (_listeners != null)
			{
				for (var i = 0; i < countBeforeExecution; i++)
				{
					var listener = _listeners[ i ];
					if (listener != null)
					{
						listener( t0, t1 );
					}
				}
			}

			_executionCount--;
			
			if (_executionCount == 0 && _didRemoveFromList)
			{
				if (_listeners != null)
				{
					_listeners.RemoveAll( c => c == null );
				}
				_didRemoveFromList = false;
			}
		}

		public void AddListener (Action<T0,T1> callback)
		{
			if (_fastInvocationListener == null) {
				_fastInvocationListener = callback;
				return;
			}

			if (_fastInvocationListener == callback)
			{
				return;
			}
			
			if (_listeners == null)
			{
				_listeners = new List<Action<T0,T1>>();
			}
			
			if (!_listeners.Contains(callback)) {
				_listeners.Add(callback);
			}
		}
		
		public void RemoveListener (Action<T0,T1> callback)
		{
			if (_fastInvocationListener == callback)
			{
				_fastInvocationListener = null;
			} else if (_listeners != null)
			{
				var index =_listeners.IndexOf(callback);
				if (index != -1)
				{
					_listeners[ index ] = null;
					_didRemoveFromList = true;
				}
			}
		}

		public void RemoveAllListeners ()
		{
			_fastInvocationListener = null;
			if (_listeners != null)
			{
				_listeners.Clear();
				_didRemoveFromList = true;
			}
		}
	}
}