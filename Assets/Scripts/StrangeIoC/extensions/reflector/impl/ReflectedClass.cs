/**
 * @class strange.extensions.reflector.impl.ReflectedClass
 * 
 * A reflection of a class.
 * 
 * A reflection represents the already-reflected class, complete with the preferred
 * constructor, the constructor parameters, post-constructor(s) and settable
 * values.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using strange.extensions.reflector.api;

namespace strange.extensions.reflector.impl
{
	public class ReflectedClass : IReflectedClass
	{
		public ConstructorInfo Constructor{ get; set;}
		public Type[] ConstructorParameters{ get; set;}
		public object[] ConstructorParameterNames { get; set; }
		public MethodInfo[] PostConstructors{ get; set;}
		public KeyValuePair<Type, PropertyInfo>[] Setters{ get; set;}
		public object[] SetterNames{ get; set;}
		public bool PreGenerated{ get; set;}

		/// [Obsolete"Strange migration to conform to C# guidelines. Removing camelCased publics"]
		public ConstructorInfo constructor{ get { return Constructor; } set { Constructor = value; }}
		public Type[] constructorParameters{ get { return ConstructorParameters; } set { ConstructorParameters = value; }}
		public MethodInfo[] postConstructors{ get { return PostConstructors; } set { PostConstructors = value; }}
		public KeyValuePair<MethodInfo, Attribute>[] attrMethods { get; set; }
		public KeyValuePair<Type, PropertyInfo>[] setters{ get { return Setters; } set { Setters = value; }}
		public object[] setterNames{ get { return SetterNames; } set { SetterNames = value; }}
		public bool preGenerated{ get { return PreGenerated; } set { PreGenerated = value; }}

		public bool hasSetterFor(Type type)
		{
			foreach (KeyValuePair<Type, PropertyInfo> setterType in setters)
			{
				if (setterType.Key == type)
				{
					return true;
				}
			}
			return false;
		}
	}
}
