using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class covariance
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static covariance() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.covariance");
		}

		public class EllipticEnvelope : PythonObject
		{
			public EllipticEnvelope(bool store_precision = true, bool assume_centered = false, float? support_fraction = null, float contamination = 0.1f, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				if (support_fraction != null)
				{
					pyDict["support_fraction"] = ToPython(support_fraction);
				}
				pyDict["contamination"] = ToPython(contamination);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.covariance.self.InvokeMethod("EllipticEnvelope", args, pyDict);
			}

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public NDarray support_ => ToCsharp<NDarray>(self.GetAttr("support_"));

			public float offset_ => ToCsharp<float>(self.GetAttr("offset_"));

			public NDarray raw_location_ => ToCsharp<NDarray>(self.GetAttr("raw_location_"));

			public NDarray raw_covariance_ => ToCsharp<NDarray>(self.GetAttr("raw_covariance_"));

			public NDarray raw_support_ => ToCsharp<NDarray>(self.GetAttr("raw_support_"));

			public NDarray dist_ => ToCsharp<NDarray>(self.GetAttr("dist_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray correct_covariance(NDarray data)
			{
				PyTuple args = ToTuple(new object[] {data});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("correct_covariance", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public EllipticEnvelope fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray reweight_covariance(NDarray data)
			{
				PyTuple args = ToTuple(new object[] {data});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("reweight_covariance", args, pyDict);
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

			public NDarray score_samples(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score_samples", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public EllipticEnvelope set_params(PyDict? @params = null)
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

			public EllipticEnvelope set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class EmpiricalCovariance : PythonObject
		{
			public EmpiricalCovariance(bool store_precision = true, bool assume_centered = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				self = sklearn.covariance.self.InvokeMethod("EmpiricalCovariance", args, pyDict);
			}

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public EmpiricalCovariance fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public EmpiricalCovariance set_params(PyDict? @params = null)
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

			public EmpiricalCovariance set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class GraphicalLasso : PythonObject
		{
			public GraphicalLasso(float alpha = 0.01f, string mode = "cd", string? covariance = null, float tol = 0.0001f, float enet_tol = 0.0001f, int max_iter = 100, bool verbose = false, float eps = float.Epsilon, bool assume_centered = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["alpha"] = ToPython(alpha);
				pyDict["mode"] = ToPython(mode);
				if (covariance != null)
				{
					pyDict["covariance"] = ToPython(covariance);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["enet_tol"] = ToPython(enet_tol);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["eps"] = ToPython(eps);
				pyDict["assume_centered"] = ToPython(assume_centered);
				self = sklearn.covariance.self.InvokeMethod("GraphicalLasso", args, pyDict);
			}

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public PyObject costs_ => self.GetAttr("costs_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public GraphicalLasso fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public GraphicalLasso set_params(PyDict? @params = null)
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

			public GraphicalLasso set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class GraphicalLassoCV : PythonObject
		{
			public GraphicalLassoCV(float alphas = 4, int n_refinements = 4, int? cv = null, float tol = 0.0001f, float enet_tol = 0.0001f, int max_iter = 100, string mode = "cd", int? n_jobs = null, bool verbose = false, float eps = float.Epsilon, bool assume_centered = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["alphas"] = ToPython(alphas);
				pyDict["n_refinements"] = ToPython(n_refinements);
				if (cv != null)
				{
					pyDict["cv"] = ToPython(cv);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["enet_tol"] = ToPython(enet_tol);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["mode"] = ToPython(mode);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["eps"] = ToPython(eps);
				pyDict["assume_centered"] = ToPython(assume_centered);
				self = sklearn.covariance.self.InvokeMethod("GraphicalLassoCV", args, pyDict);
			}

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public PyObject costs_ => self.GetAttr("costs_");

			public float alpha_ => ToCsharp<float>(self.GetAttr("alpha_"));

			public NDarray cv_results_ => ToCsharp<NDarray>(self.GetAttr("cv_results_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public GraphicalLassoCV fit(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public GraphicalLassoCV set_params(PyDict? @params = null)
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

			public GraphicalLassoCV set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class LedoitWolf : PythonObject
		{
			public LedoitWolf(bool store_precision = true, bool assume_centered = false, int block_size = 1000)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				pyDict["block_size"] = ToPython(block_size);
				self = sklearn.covariance.self.InvokeMethod("LedoitWolf", args, pyDict);
			}

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public float shrinkage_ => ToCsharp<float>(self.GetAttr("shrinkage_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public LedoitWolf fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public LedoitWolf set_params(PyDict? @params = null)
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

			public LedoitWolf set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class MinCovDet : PythonObject
		{
			public MinCovDet(bool store_precision = true, bool assume_centered = false, float? support_fraction = null, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				if (support_fraction != null)
				{
					pyDict["support_fraction"] = ToPython(support_fraction);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.covariance.self.InvokeMethod("MinCovDet", args, pyDict);
			}

			public NDarray raw_location_ => ToCsharp<NDarray>(self.GetAttr("raw_location_"));

			public NDarray raw_covariance_ => ToCsharp<NDarray>(self.GetAttr("raw_covariance_"));

			public NDarray raw_support_ => ToCsharp<NDarray>(self.GetAttr("raw_support_"));

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public NDarray support_ => ToCsharp<NDarray>(self.GetAttr("support_"));

			public NDarray dist_ => ToCsharp<NDarray>(self.GetAttr("dist_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray correct_covariance(NDarray data)
			{
				PyTuple args = ToTuple(new object[] {data});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("correct_covariance", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public MinCovDet fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray reweight_covariance(NDarray data)
			{
				PyTuple args = ToTuple(new object[] {data});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("reweight_covariance", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public MinCovDet set_params(PyDict? @params = null)
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

			public MinCovDet set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class OAS : PythonObject
		{
			public OAS(bool store_precision = true, bool assume_centered = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				self = sklearn.covariance.self.InvokeMethod("OAS", args, pyDict);
			}

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public float shrinkage_ => ToCsharp<float>(self.GetAttr("shrinkage_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public OAS fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public OAS set_params(PyDict? @params = null)
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

			public OAS set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

		public class ShrunkCovariance : PythonObject
		{
			public ShrunkCovariance(bool store_precision = true, bool assume_centered = false, float shrinkage = 0.1f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["store_precision"] = ToPython(store_precision);
				pyDict["assume_centered"] = ToPython(assume_centered);
				pyDict["shrinkage"] = ToPython(shrinkage);
				self = sklearn.covariance.self.InvokeMethod("ShrunkCovariance", args, pyDict);
			}

			public NDarray covariance_ => ToCsharp<NDarray>(self.GetAttr("covariance_"));

			public NDarray location_ => ToCsharp<NDarray>(self.GetAttr("location_"));

			public NDarray precision_ => ToCsharp<NDarray>(self.GetAttr("precision_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float error_norm(NDarray comp_cov, string norm = "frobenius", bool scaling = true, bool squared = true)
			{
				PyTuple args = ToTuple(new object[] {comp_cov});
				PyDict pyDict = new PyDict();
				pyDict["norm"] = ToPython(norm);
				pyDict["scaling"] = ToPython(scaling);
				pyDict["squared"] = ToPython(squared);
				PyObject result = self.InvokeMethod("error_norm", args, pyDict);
				return ToCsharp<float>(result);
			}

			public ShrunkCovariance fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray mahalanobis(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("mahalanobis", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X_test)
			{
				PyTuple args = ToTuple(new object[] {X_test});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public ShrunkCovariance set_params(PyDict? @params = null)
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

			public ShrunkCovariance set_score_request(string? X_test = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X_test != null)
				{
					pyDict["X_test"] = ToPython(X_test);
				}
				self.InvokeMethod("set_score_request", args, pyDict);
				return this;
			}

		}

	}
}
