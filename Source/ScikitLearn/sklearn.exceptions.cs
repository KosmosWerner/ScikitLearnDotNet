using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class exceptions
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static exceptions() => ReInitializeLazySelf();

		private static void ReInitializeLazySelf()
		{
			_lazy_self = new Lazy<PyObject>(delegate
			{
				try { return InstallAndImport(); }
				catch (Exception) { return InstallAndImport(force: true); }
			});
		}

		private static PyObject InstallAndImport(bool force = false)
		{
			PythonEngine.AddShutdownHandler(ReInitializeLazySelf);
			PythonEngine.Initialize();
			return Py.Import("sklearn.exceptions");
		}

		public class ConvergenceWarning : PythonObject
		{
			public ConvergenceWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("ConvergenceWarning", args, pyDict);
			}

		}

		public class DataConversionWarning : PythonObject
		{
			public DataConversionWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("DataConversionWarning", args, pyDict);
			}

		}

		public class DataDimensionalityWarning : PythonObject
		{
			public DataDimensionalityWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("DataDimensionalityWarning", args, pyDict);
			}

		}

		public class EfficiencyWarning : PythonObject
		{
			public EfficiencyWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("EfficiencyWarning", args, pyDict);
			}

		}

		public class FitFailedWarning : PythonObject
		{
			public FitFailedWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("FitFailedWarning", args, pyDict);
			}

		}

		public class InconsistentVersionWarning : PythonObject
		{
			public InconsistentVersionWarning(string estimator_name, string current_sklearn_version, string original_sklearn_version)
			{
				PyTuple args = ToTuple(new object[] {estimator_name, current_sklearn_version, original_sklearn_version});
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("InconsistentVersionWarning", args, pyDict);
			}

		}

		public class NotFittedError : PythonObject
		{
			public NotFittedError()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("NotFittedError", args, pyDict);
			}

		}

		public class UndefinedMetricWarning : PythonObject
		{
			public UndefinedMetricWarning()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.exceptions.self.InvokeMethod("UndefinedMetricWarning", args, pyDict);
			}

		}

	}
}
