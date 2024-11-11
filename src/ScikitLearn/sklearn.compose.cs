using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class compose
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static compose() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.compose");
		}

		public class ColumnTransformer : PythonObject
		{
			public ColumnTransformer(PyObject transformers, string remainder = "drop", float sparse_threshold = 0.3f, int? n_jobs = null, PyObject transformer_weights = null, bool verbose = false, bool verbose_feature_names_out = true, bool force_int_remainder_cols = true)
			{
				PyTuple args = ToTuple(new object[] {transformers});
				PyDict pyDict = new PyDict();
				pyDict["remainder"] = ToPython(remainder);
				pyDict["sparse_threshold"] = ToPython(sparse_threshold);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["transformer_weights"] = ToPython(transformer_weights);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["verbose_feature_names_out"] = ToPython(verbose_feature_names_out);
				pyDict["force_int_remainder_cols"] = ToPython(force_int_remainder_cols);
				self = sklearn.compose.self.InvokeMethod("ColumnTransformer", args, pyDict);
			}

			public PyObject transformers_ => self.GetAttr("transformers_");

			public bool sparse_output_ => ToCsharp<bool>(self.GetAttr("sparse_output_"));

			public PyObject output_indices_ => self.GetAttr("output_indices_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public ColumnTransformer fit(NDarray X, NDarray? y = null, PyDict? @params = null)
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
				self.InvokeMethod("fit", args, pyDict);
				return this;
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

			public ColumnTransformer set_output(string? transform = null)
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

			public ColumnTransformer set_params(PyDict? @params = null)
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

			public NDarray transform(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class TransformedTargetRegressor : PythonObject
		{
			public TransformedTargetRegressor(PyObject regressor = null, PyObject transformer = null, PyObject func = null, PyObject inverse_func = null, bool check_inverse = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["regressor"] = ToPython(regressor);
				pyDict["transformer"] = ToPython(transformer);
				pyDict["func"] = ToPython(func);
				pyDict["inverse_func"] = ToPython(inverse_func);
				pyDict["check_inverse"] = ToPython(check_inverse);
				self = sklearn.compose.self.InvokeMethod("TransformedTargetRegressor", args, pyDict);
			}

			public PyObject regressor_ => self.GetAttr("regressor_");

			public PyObject transformer_ => self.GetAttr("transformer_");

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public TransformedTargetRegressor fit(NDarray X, NDarray y, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public PyObject get_params(bool deep = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["deep"] = ToPython(deep);
				PyObject result = self.InvokeMethod("get_params", args, pyDict);
				return result;
			}

			public NDarray predict(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
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

			public TransformedTargetRegressor set_params(PyDict? @params = null)
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

			public TransformedTargetRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class make_column_selector : PythonObject
		{
			public make_column_selector(string? pattern = null, PyObject dtype_include = null, PyObject dtype_exclude = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (pattern != null)
				{
					pyDict["pattern"] = ToPython(pattern);
				}
				pyDict["dtype_include"] = ToPython(dtype_include);
				pyDict["dtype_exclude"] = ToPython(dtype_exclude);
				self = sklearn.compose.self.InvokeMethod("make_column_selector", args, pyDict);
			}
		}
	}
}
