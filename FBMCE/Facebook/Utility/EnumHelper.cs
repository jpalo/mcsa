using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Facebook.Utility
{
	public class EnumHelper
	{
		private EnumHelper()
		{
		}

		public static string GetEnumDescription<T>(T enumeratedType)
		{
			string description = enumeratedType.ToString();

			//description not supported on netcf
#if !NETCF
			Type enumType = typeof (T);
			// Can't use type constraints on value types, so have to do check like this
			if (enumType.BaseType != typeof (Enum))
				throw new ArgumentException("T must be of type System.Enum");

			FieldInfo fieldInfo =
				enumeratedType.GetType().GetField(enumeratedType.ToString());

			if (fieldInfo != null)
			{
				object[] attributes =
					fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false);

				if (attributes != null && attributes.Length > 0)
				{
					description = ((DescriptionAttribute) attributes[0]).Description;
				}
			}
#endif
			return description;
		}

		public static string GetEnumCollectionDescription<T>(Collection<T> enums)
		{
			var sb = new StringBuilder();

			Type enumType = typeof (T);
			// Can't use type constraints on value types, so have to do check like this
			if (enumType.BaseType != typeof (Enum))
				throw new ArgumentException("T must be of type System.Enum");

			foreach (T enumeratedType in enums)
			{
#if NETCF
                sb.Append(GetEnumDescription(enumeratedType));
                sb.Append("\r\n");
#else
				sb.AppendLine(GetEnumDescription(enumeratedType));
#endif
			}

			return sb.ToString();
		}
	}
}