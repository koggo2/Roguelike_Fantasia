using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Text;

public static class Debug
	{
		public static void Log (params object[] objectList)
		{
#if UNITY_EDITOR
			if (objectList == null)
				return;

			StackTrace st = new StackTrace ();
			MethodBase mb = st.GetFrame (1).GetMethod ();

			string log = "<color=green>[" + mb.DeclaringType + "::" + mb.Name + "]</color>";
			for (int i = 0; i < objectList.Length; ++i) {
				if (objectList [i] == null) {
					log += ", null";
				} else {
					if (objectList [i] is IEnumerable) {
						log += ", " + IEnumerableToString (objectList [i] as IEnumerable);
					} else {
						log += ", " + objectList [i].ToString ();
					}
				}
			}
			
			UnityEngine.Debug.Log (log);
#endif
		}
		
		public static void LogError (params object[] objectList)
		{
#if UNITY_EDITOR 
			if (objectList == null)
				return;
			
			StackTrace st = new StackTrace ();
			MethodBase mb = st.GetFrame (1).GetMethod ();

			string log = "<color=red>[" + mb.DeclaringType + "::" + mb.Name + "]</color>";
			for (int i = 0; i < objectList.Length; ++i) {
				if (objectList [i] == null) {
					log += ", null";
				} else {
					if (objectList [i] is IEnumerable) {
						log += ", " + IEnumerableToString (objectList [i] as IEnumerable);
					} else {
						log += ", " + objectList [i].ToString ();
					}
				}
			}

			UnityEngine.Debug.LogError (log);
#endif
		}

        public static void LogWarning (params object[] objectList)
        {
#if UNITY_EDITOR
            if (objectList == null)
                return;

            StackTrace st = new StackTrace ();
            MethodBase mb = st.GetFrame (1).GetMethod ();

            string log = "<color=yellow>[" + mb.DeclaringType + "::" + mb.Name + "]</color>";
            for (int i = 0; i < objectList.Length; ++i) {
                if (objectList [i] == null) {
                    log += ", null";
                } else {
                    if (objectList [i] is IEnumerable) {
                        log += ", " + IEnumerableToString (objectList [i] as IEnumerable);
                    } else {
                        log += ", " + objectList [i].ToString ();
                    }
                }
            }

            UnityEngine.Debug.LogError (log);
#endif
        }

		public static void LogException(Exception e)
		{
#if UNITY_EDITOR
			UnityEngine.Debug.LogException(e);
#endif
		}

		private static string IEnumerableToString (IEnumerable enumerable)
		{
			if (enumerable is string)
				return enumerable.ToString ();

			string message = "<color=yellow>{";

			foreach (var item in enumerable) {
				message += item.ToString () + ", ";
			}

			return message += "}</color>";
		}
	}
