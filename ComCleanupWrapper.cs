using System;
using System.Runtime.InteropServices;

namespace Extensions
{
	/// <summary>
	/// https://github.com/JakeGinnivan/VSTOContrib/blob/master/src/VSTOContrib.Core/Extensions/ComCleanupExtensions.cs
	/// var comObject = ...;
	/// 
	/// using(var wrapped = comObject.WithComCleanup())
	/// {
	/// 	wrapped.Resource.DoComMethod();
	/// 	
	/// 	using(var inner = wrapper.Resource.InnerObject.WithComCleanup())
	/// 	{
	/// 		...
	/// 	}
	/// }
	/// </summary>
	public static class ObjectExtensions
	{
		public static ComObjectWrapper<T> WithComCleanup<T>(this T resource) where T : class
		{
			return new ComObjectWrapper<T>(resource);
		}
	}
	
	/// <summary>
	/// https://github.com/JakeGinnivan/VSTOContrib/blob/master/src/VSTOContrib.Core/Extensions/ComObjectWrapper.cs
	/// </summary>
	public class ComObjectWrapper<T> : IDisposable where T : class
	{
		private T _resource;
		
		public T Resource
		{
			get
			{	
				if(_resource == null)
				{
					throw new ObjectDisposedException("Resource");
				}
				
				return _resource;
			}
		}
		
		public ComObjectWrapper(T resource)
		{
			if(resource == null)
			{
				throw new ArgumentNullException("Resource");
			}
			_resource = resource;
		}
		
		public void Dispose()
		{
			if(Marshal.IsComObject(_resource))
			{
				Marshal.ReleaseComObject(_resource);
			}
			
			_resource = null;
		}
	}
}