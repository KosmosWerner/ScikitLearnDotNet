using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class @base
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static @base() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.base");
		}

		public class BaseEstimator : PythonObject
		{
			public BaseEstimator()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("BaseEstimator", args, pyDict);
			}

			public PyObject get_metadata_routing()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_metadata_routing", args, pyDict);
				return result;
			}

			public PyObject get_params(bool deep = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["deep"] = ToPython(deep);
				PyObject result = self.InvokeMethod("get_params", args, pyDict);
				return result;
			}

			public BaseEstimator set_params(PyDict? @params = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				self.InvokeMethod("set_params", args, pyDict);
				return this;
			}

		}

		public class BiclusterMixin : PythonObject
		{
			public BiclusterMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("BiclusterMixin", args, pyDict);
			}

			public NDarray get_indices(int i)
			{
				PyTuple args = ToTuple(new object[] {i});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_indices", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public int get_shape(int i)
			{
				PyTuple args = ToTuple(new object[] {i});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_shape", args, pyDict);
				return ToCsharp<int>(result);
			}

			public NDarray get_submatrix(int i, NDarray data)
			{
				PyTuple args = ToTuple(new object[] {i, data});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_submatrix", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class ClassNamePrefixFeaturesOutMixin : PythonObject
		{
			public ClassNamePrefixFeaturesOutMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("ClassNamePrefixFeaturesOutMixin", args, pyDict);
			}

			public NDarray get_feature_names_out(string? input_features = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (input_features != null)
				{
					pyDict["input_features"] = ToPython(input_features);
				}
				PyObject result = self.InvokeMethod("get_feature_names_out", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class ClassifierMixin : PythonObject
		{
			public ClassifierMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("ClassifierMixin", args, pyDict);
			}

			public float score(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

		}

		public class ClusterMixin : PythonObject
		{
			public ClusterMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("ClusterMixin", args, pyDict);
			}

			public NDarray fit_predict(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("fit_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class DensityMixin : PythonObject
		{
			public DensityMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("DensityMixin", args, pyDict);
			}

			public float score(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

		}

		public class MetaEstimatorMixin : PythonObject
		{
			public MetaEstimatorMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("MetaEstimatorMixin", args, pyDict);
			}

		}

		public class OneToOneFeatureMixin : PythonObject
		{
			public OneToOneFeatureMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("OneToOneFeatureMixin", args, pyDict);
			}

			public NDarray get_feature_names_out(string? input_features = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (input_features != null)
				{
					pyDict["input_features"] = ToPython(input_features);
				}
				PyObject result = self.InvokeMethod("get_feature_names_out", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class OutlierMixin : PythonObject
		{
			public OutlierMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("OutlierMixin", args, pyDict);
			}

			public NDarray fit_predict(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("fit_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class RegressorMixin : PythonObject
		{
			public RegressorMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("RegressorMixin", args, pyDict);
			}

			public float score(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

		}

		public class TransformerMixin : PythonObject
		{
			public TransformerMixin()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				self = sklearn.@base.self.InvokeMethod("TransformerMixin", args, pyDict);
			}

			public NDarray fit_transform(NDarray X, NDarray? y = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("fit_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public TransformerMixin set_output(string? transform = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (transform != null)
				{
					pyDict["transform"] = ToPython(transform);
				}
				self.InvokeMethod("set_output", args, pyDict);
				return this;
			}

		}

	}
}
