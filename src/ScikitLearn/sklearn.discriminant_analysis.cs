using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class discriminant_analysis
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static discriminant_analysis() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.discriminant_analysis");
		}

		public class LinearDiscriminantAnalysis : PythonObject
		{
			public LinearDiscriminantAnalysis(string solver = "svd", float? shrinkage = null, NDarray? priors = null, int? n_components = null, bool store_covariance = false, float tol = 0.0001f, PyObject covariance_estimator = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["solver"] = ToPython(solver);
				if (shrinkage != null)
				{
					pyDict["shrinkage"] = ToPython(shrinkage);
				}
				if (priors != null)
				{
					pyDict["priors"] = ToPython(priors);
				}
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["store_covariance"] = ToPython(store_covariance);
				pyDict["tol"] = ToPython(tol);
				pyDict["covariance_estimator"] = ToPython(covariance_estimator);
				self = sklearn.discriminant_analysis.self.InvokeMethod("LinearDiscriminantAnalysis", args, pyDict);
			}

			public NDarray coef_ => ToCsharp<NDarray>(self.GetAttr("coef_"));

			public NDarray intercept_ => ToCsharp<NDarray>(self.GetAttr("intercept_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray explained_variance_ratio_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_ratio_"));

			public NDarray means_ => ToCsharp<NDarray>(self.GetAttr("means_"));

			public NDarray priors_ => ToCsharp<NDarray>(self.GetAttr("priors_"));

			public NDarray scalings_ => ToCsharp<NDarray>(self.GetAttr("scalings_"));

			public NDarray xbar_ => ToCsharp<NDarray>(self.GetAttr("xbar_"));

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public LinearDiscriminantAnalysis fit(NDarray X, NDarray y)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict_log_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict_log_proba", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict_proba", args, pyDict);
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

			public LinearDiscriminantAnalysis set_output(string? transform = null)
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

			public LinearDiscriminantAnalysis set_params(PyDict? @params = null)
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

			public LinearDiscriminantAnalysis set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class QuadraticDiscriminantAnalysis : PythonObject
		{
			public QuadraticDiscriminantAnalysis(NDarray? priors = null, float reg_param = 0.0f, bool store_covariance = false, float tol = 0.0001f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (priors != null)
				{
					pyDict["priors"] = ToPython(priors);
				}
				pyDict["reg_param"] = ToPython(reg_param);
				pyDict["store_covariance"] = ToPython(store_covariance);
				pyDict["tol"] = ToPython(tol);
				self = sklearn.discriminant_analysis.self.InvokeMethod("QuadraticDiscriminantAnalysis", args, pyDict);
			}

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray means_ => ToCsharp<NDarray>(self.GetAttr("means_"));

			public NDarray priors_ => ToCsharp<NDarray>(self.GetAttr("priors_"));

			public NDarray rotations_ => ToCsharp<NDarray>(self.GetAttr("rotations_"));

			public NDarray scalings_ => ToCsharp<NDarray>(self.GetAttr("scalings_"));

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public QuadraticDiscriminantAnalysis fit(NDarray X, NDarray y)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict_log_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict_log_proba", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict_proba", args, pyDict);
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

			public QuadraticDiscriminantAnalysis set_params(PyDict? @params = null)
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

			public QuadraticDiscriminantAnalysis set_score_request(string? sample_weight = "$UNCHANGED$")
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

	}
}
