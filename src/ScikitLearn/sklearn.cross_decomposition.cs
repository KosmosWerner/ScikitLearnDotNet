using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class cross_decomposition
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static cross_decomposition() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.cross_decomposition");
		}

		public class CCA : PythonObject
		{
			public CCA(int n_components = 2, bool scale = true, int max_iter = 500, float tol = 1e-06f, bool copy = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				pyDict["scale"] = ToPython(scale);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cross_decomposition.self.InvokeMethod("CCA", args, pyDict);
			}

			public NDarray x_weights_ => ToCsharp<NDarray>(self.GetAttr("x_weights_"));

			public NDarray y_weights_ => ToCsharp<NDarray>(self.GetAttr("y_weights_"));

			public NDarray x_loadings_ => ToCsharp<NDarray>(self.GetAttr("x_loadings_"));

			public NDarray y_loadings_ => ToCsharp<NDarray>(self.GetAttr("y_loadings_"));

			public NDarray x_rotations_ => ToCsharp<NDarray>(self.GetAttr("x_rotations_"));

			public NDarray y_rotations_ => ToCsharp<NDarray>(self.GetAttr("y_rotations_"));

			public NDarray coef_ => ToCsharp<NDarray>(self.GetAttr("coef_"));

			public NDarray intercept_ => ToCsharp<NDarray>(self.GetAttr("intercept_"));

			public NDarray n_iter_ => ToCsharp<NDarray>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public CCA fit(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public CCA fit_transform(NDarray X, NDarray? y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				self.InvokeMethod("fit_transform", args, pyDict);
				return this;
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

			public NDarray inverse_transform(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict(NDarray X, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["copy"] = ToPython(copy);
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

			public CCA set_output(string? transform = null)
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

			public CCA set_params(PyDict? @params = null)
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

			public CCA set_predict_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_predict_request", args, pyDict);
				return this;
			}

			public CCA set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public CCA set_transform_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_transform_request", args, pyDict);
				return this;
			}

			public NDarray transform(NDarray X, NDarray? y = null, NDarray? Y = null, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				if (Y != null)
				{
					pyDict["Y"] = ToPython(Y);
				}
				pyDict["copy"] = ToPython(copy);
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class PLSCanonical : PythonObject
		{
			public PLSCanonical(int n_components = 2, bool scale = true, string algorithm = "nipals", int max_iter = 500, float tol = 1e-06f, bool copy = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				pyDict["scale"] = ToPython(scale);
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cross_decomposition.self.InvokeMethod("PLSCanonical", args, pyDict);
			}

			public NDarray x_weights_ => ToCsharp<NDarray>(self.GetAttr("x_weights_"));

			public NDarray y_weights_ => ToCsharp<NDarray>(self.GetAttr("y_weights_"));

			public NDarray x_loadings_ => ToCsharp<NDarray>(self.GetAttr("x_loadings_"));

			public NDarray y_loadings_ => ToCsharp<NDarray>(self.GetAttr("y_loadings_"));

			public NDarray x_rotations_ => ToCsharp<NDarray>(self.GetAttr("x_rotations_"));

			public NDarray y_rotations_ => ToCsharp<NDarray>(self.GetAttr("y_rotations_"));

			public NDarray coef_ => ToCsharp<NDarray>(self.GetAttr("coef_"));

			public NDarray intercept_ => ToCsharp<NDarray>(self.GetAttr("intercept_"));

			public NDarray n_iter_ => ToCsharp<NDarray>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PLSCanonical fit(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public PLSCanonical fit_transform(NDarray X, NDarray? y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				self.InvokeMethod("fit_transform", args, pyDict);
				return this;
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

			public NDarray inverse_transform(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict(NDarray X, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["copy"] = ToPython(copy);
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

			public PLSCanonical set_output(string? transform = null)
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

			public PLSCanonical set_params(PyDict? @params = null)
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

			public PLSCanonical set_predict_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_predict_request", args, pyDict);
				return this;
			}

			public PLSCanonical set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public PLSCanonical set_transform_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_transform_request", args, pyDict);
				return this;
			}

			public NDarray transform(NDarray X, NDarray? y = null, NDarray? Y = null, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				if (Y != null)
				{
					pyDict["Y"] = ToPython(Y);
				}
				pyDict["copy"] = ToPython(copy);
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class PLSRegression : PythonObject
		{
			public PLSRegression(int n_components = 2, bool scale = true, int max_iter = 500, float tol = 1e-06f, bool copy = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				pyDict["scale"] = ToPython(scale);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cross_decomposition.self.InvokeMethod("PLSRegression", args, pyDict);
			}

			public NDarray x_weights_ => ToCsharp<NDarray>(self.GetAttr("x_weights_"));

			public NDarray y_weights_ => ToCsharp<NDarray>(self.GetAttr("y_weights_"));

			public NDarray x_loadings_ => ToCsharp<NDarray>(self.GetAttr("x_loadings_"));

			public NDarray y_loadings_ => ToCsharp<NDarray>(self.GetAttr("y_loadings_"));

			public NDarray x_scores_ => ToCsharp<NDarray>(self.GetAttr("x_scores_"));

			public NDarray y_scores_ => ToCsharp<NDarray>(self.GetAttr("y_scores_"));

			public NDarray x_rotations_ => ToCsharp<NDarray>(self.GetAttr("x_rotations_"));

			public NDarray y_rotations_ => ToCsharp<NDarray>(self.GetAttr("y_rotations_"));

			public NDarray coef_ => ToCsharp<NDarray>(self.GetAttr("coef_"));

			public NDarray intercept_ => ToCsharp<NDarray>(self.GetAttr("intercept_"));

			public NDarray n_iter_ => ToCsharp<NDarray>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PLSRegression fit(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public PLSRegression fit_transform(NDarray X, NDarray? y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				self.InvokeMethod("fit_transform", args, pyDict);
				return this;
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

			public NDarray inverse_transform(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict(NDarray X, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["copy"] = ToPython(copy);
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

			public PLSRegression set_output(string? transform = null)
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

			public PLSRegression set_params(PyDict? @params = null)
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

			public PLSRegression set_predict_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_predict_request", args, pyDict);
				return this;
			}

			public PLSRegression set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public PLSRegression set_transform_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_transform_request", args, pyDict);
				return this;
			}

			public NDarray transform(NDarray X, NDarray? y = null, NDarray? Y = null, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				if (Y != null)
				{
					pyDict["Y"] = ToPython(Y);
				}
				pyDict["copy"] = ToPython(copy);
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class PLSSVD : PythonObject
		{
			public PLSSVD(int n_components = 2, bool scale = true, bool copy = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				pyDict["scale"] = ToPython(scale);
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cross_decomposition.self.InvokeMethod("PLSSVD", args, pyDict);
			}

			public NDarray x_weights_ => ToCsharp<NDarray>(self.GetAttr("x_weights_"));

			public NDarray y_weights_ => ToCsharp<NDarray>(self.GetAttr("y_weights_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PLSSVD fit(NDarray X, NDarray y = null, NDarray Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				pyDict["Y"] = ToPython(Y);
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X, NDarray? y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
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

			public PLSSVD set_output(string? transform = null)
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

			public PLSSVD set_params(PyDict? @params = null)
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

			public NDarray transform(NDarray X, NDarray? y = null, NDarray? Y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (y != null)
				{
					pyDict["y"] = ToPython(y);
				}
				if (Y != null)
				{
					pyDict["Y"] = ToPython(Y);
				}
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

	}
}
