using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class ensemble
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static ensemble() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.ensemble");
		}

		public class AdaBoostClassifier : PythonObject
		{
			public AdaBoostClassifier(PyObject estimator = null, int n_estimators = 50, float learning_rate = 1.0f, string algorithm = "SAMME.R", int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["estimator"] = ToPython(estimator);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["algorithm"] = ToPython(algorithm);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.ensemble.self.InvokeMethod("AdaBoostClassifier", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_classes_ => ToCsharp<int>(self.GetAttr("n_classes_"));

			public NDarray estimator_weights_ => ToCsharp<NDarray>(self.GetAttr("estimator_weights_"));

			public NDarray estimator_errors_ => ToCsharp<NDarray>(self.GetAttr("estimator_errors_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public AdaBoostClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public AdaBoostClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public AdaBoostClassifier set_params(PyDict? @params = null)
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

			public AdaBoostClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict_proba", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float staged_score(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("staged_score", args, pyDict);
				return ToCsharp<float>(result);
			}

		}

		public class AdaBoostRegressor : PythonObject
		{
			public AdaBoostRegressor(PyObject estimator = null, int n_estimators = 50, float learning_rate = 1.0f, string loss = "linear", int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["estimator"] = ToPython(estimator);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["loss"] = ToPython(loss);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.ensemble.self.InvokeMethod("AdaBoostRegressor", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray estimator_weights_ => ToCsharp<NDarray>(self.GetAttr("estimator_weights_"));

			public NDarray estimator_errors_ => ToCsharp<NDarray>(self.GetAttr("estimator_errors_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public AdaBoostRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public AdaBoostRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public AdaBoostRegressor set_params(PyDict? @params = null)
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

			public AdaBoostRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float staged_score(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("staged_score", args, pyDict);
				return ToCsharp<float>(result);
			}

		}

		public class BaggingClassifier : PythonObject
		{
			public BaggingClassifier(PyObject estimator = null, int n_estimators = 10, int max_samples = 1, int max_features = 1, bool bootstrap = true, bool bootstrap_features = false, bool oob_score = false, bool warm_start = false, int? n_jobs = null, int? random_state = null, int verbose = 0)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["estimator"] = ToPython(estimator);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["max_samples"] = ToPython(max_samples);
				pyDict["max_features"] = ToPython(max_features);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["bootstrap_features"] = ToPython(bootstrap_features);
				pyDict["oob_score"] = ToPython(oob_score);
				pyDict["warm_start"] = ToPython(warm_start);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("BaggingClassifier", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray estimators_features_ => ToCsharp<NDarray>(self.GetAttr("estimators_features_"));

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_classes_ => ToCsharp<int>(self.GetAttr("n_classes_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_decision_function_ => ToCsharp<NDarray>(self.GetAttr("oob_decision_function_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public BaggingClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
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

			public BaggingClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public BaggingClassifier set_params(PyDict? @params = null)
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

			public BaggingClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class BaggingRegressor : PythonObject
		{
			public BaggingRegressor(PyObject estimator = null, int n_estimators = 10, int max_samples = 1, int max_features = 1, bool bootstrap = true, bool bootstrap_features = false, bool oob_score = false, bool warm_start = false, int? n_jobs = null, int? random_state = null, int verbose = 0)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["estimator"] = ToPython(estimator);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["max_samples"] = ToPython(max_samples);
				pyDict["max_features"] = ToPython(max_features);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["bootstrap_features"] = ToPython(bootstrap_features);
				pyDict["oob_score"] = ToPython(oob_score);
				pyDict["warm_start"] = ToPython(warm_start);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("BaggingRegressor", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray estimators_features_ => ToCsharp<NDarray>(self.GetAttr("estimators_features_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_prediction_ => ToCsharp<NDarray>(self.GetAttr("oob_prediction_"));

			public BaggingRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public BaggingRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public BaggingRegressor set_params(PyDict? @params = null)
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

			public BaggingRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class ExtraTreesClassifier : PythonObject
		{
			public ExtraTreesClassifier(int n_estimators = 100, string criterion = "gini", int? max_depth = null, float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, string? max_features = "sqrt", int? max_leaf_nodes = null, float min_impurity_decrease = 0.0f, bool bootstrap = false, bool oob_score = false, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false, string? class_weight = null, float ccp_alpha = 0.0f, int? max_samples = null, NDarray? monotonic_cst = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["criterion"] = ToPython(criterion);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["oob_score"] = ToPython(oob_score);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				if (class_weight != null)
				{
					pyDict["class_weight"] = ToPython(class_weight);
				}
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				if (max_samples != null)
				{
					pyDict["max_samples"] = ToPython(max_samples);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				self = sklearn.ensemble.self.InvokeMethod("ExtraTreesClassifier", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_classes_ => ToCsharp<int>(self.GetAttr("n_classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_outputs_ => ToCsharp<int>(self.GetAttr("n_outputs_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_decision_function_ => ToCsharp<NDarray>(self.GetAttr("oob_decision_function_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_path(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_path", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public ExtraTreesClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public ExtraTreesClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public ExtraTreesClassifier set_params(PyDict? @params = null)
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

			public ExtraTreesClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class ExtraTreesRegressor : PythonObject
		{
			public ExtraTreesRegressor(int n_estimators = 100, string criterion = "squared_error", int? max_depth = null, float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, int? max_features = 1, int? max_leaf_nodes = null, float min_impurity_decrease = 0.0f, bool bootstrap = false, bool oob_score = false, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false, float ccp_alpha = 0.0f, int? max_samples = null, NDarray? monotonic_cst = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["criterion"] = ToPython(criterion);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["oob_score"] = ToPython(oob_score);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				if (max_samples != null)
				{
					pyDict["max_samples"] = ToPython(max_samples);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				self = sklearn.ensemble.self.InvokeMethod("ExtraTreesRegressor", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_outputs_ => ToCsharp<int>(self.GetAttr("n_outputs_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_prediction_ => ToCsharp<NDarray>(self.GetAttr("oob_prediction_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_path(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_path", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public ExtraTreesRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public ExtraTreesRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public ExtraTreesRegressor set_params(PyDict? @params = null)
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

			public ExtraTreesRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class GradientBoostingClassifier : PythonObject
		{
			public GradientBoostingClassifier(string loss = "log_loss", float learning_rate = 0.1f, int n_estimators = 100, float subsample = 1.0f, string criterion = "friedman_mse", float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, int? max_depth = 3, float min_impurity_decrease = 0.0f, string? init = null, int? random_state = null, int? max_features = null, int verbose = 0, int? max_leaf_nodes = null, bool warm_start = false, float validation_fraction = 0.1f, int? n_iter_no_change = null, float tol = 0.0001f, float ccp_alpha = 0.0f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["loss"] = ToPython(loss);
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["subsample"] = ToPython(subsample);
				pyDict["criterion"] = ToPython(criterion);
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				if (init != null)
				{
					pyDict["init"] = ToPython(init);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				pyDict["verbose"] = ToPython(verbose);
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["validation_fraction"] = ToPython(validation_fraction);
				if (n_iter_no_change != null)
				{
					pyDict["n_iter_no_change"] = ToPython(n_iter_no_change);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				self = sklearn.ensemble.self.InvokeMethod("GradientBoostingClassifier", args, pyDict);
			}

			public int n_estimators_ => ToCsharp<int>(self.GetAttr("n_estimators_"));

			public int n_trees_per_iteration_ => ToCsharp<int>(self.GetAttr("n_trees_per_iteration_"));

			public NDarray oob_improvement_ => ToCsharp<NDarray>(self.GetAttr("oob_improvement_"));

			public NDarray oob_scores_ => ToCsharp<NDarray>(self.GetAttr("oob_scores_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray train_score_ => ToCsharp<NDarray>(self.GetAttr("train_score_"));

			public PyObject init_ => self.GetAttr("init_");

			public NDarray estimators_ => ToCsharp<NDarray>(self.GetAttr("estimators_"));

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_classes_ => ToCsharp<int>(self.GetAttr("n_classes_"));

			public int max_features_ => ToCsharp<int>(self.GetAttr("max_features_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public GradientBoostingClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyObject monitor = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				pyDict["monitor"] = ToPython(monitor);
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

			public GradientBoostingClassifier set_fit_request(string? monitor = "$UNCHANGED$", string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (monitor != null)
				{
					pyDict["monitor"] = ToPython(monitor);
				}
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public GradientBoostingClassifier set_params(PyDict? @params = null)
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

			public GradientBoostingClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict_proba", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class GradientBoostingRegressor : PythonObject
		{
			public GradientBoostingRegressor(string loss = "squared_error", float learning_rate = 0.1f, int n_estimators = 100, float subsample = 1.0f, string criterion = "friedman_mse", float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, int? max_depth = 3, float min_impurity_decrease = 0.0f, string? init = null, int? random_state = null, int? max_features = null, float alpha = 0.9f, int verbose = 0, int? max_leaf_nodes = null, bool warm_start = false, float validation_fraction = 0.1f, int? n_iter_no_change = null, float tol = 0.0001f, float ccp_alpha = 0.0f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["loss"] = ToPython(loss);
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["subsample"] = ToPython(subsample);
				pyDict["criterion"] = ToPython(criterion);
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				if (init != null)
				{
					pyDict["init"] = ToPython(init);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				pyDict["alpha"] = ToPython(alpha);
				pyDict["verbose"] = ToPython(verbose);
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["validation_fraction"] = ToPython(validation_fraction);
				if (n_iter_no_change != null)
				{
					pyDict["n_iter_no_change"] = ToPython(n_iter_no_change);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				self = sklearn.ensemble.self.InvokeMethod("GradientBoostingRegressor", args, pyDict);
			}

			public int n_estimators_ => ToCsharp<int>(self.GetAttr("n_estimators_"));

			public int n_trees_per_iteration_ => ToCsharp<int>(self.GetAttr("n_trees_per_iteration_"));

			public NDarray oob_improvement_ => ToCsharp<NDarray>(self.GetAttr("oob_improvement_"));

			public NDarray oob_scores_ => ToCsharp<NDarray>(self.GetAttr("oob_scores_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray train_score_ => ToCsharp<NDarray>(self.GetAttr("train_score_"));

			public PyObject init_ => self.GetAttr("init_");

			public NDarray estimators_ => ToCsharp<NDarray>(self.GetAttr("estimators_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int max_features_ => ToCsharp<int>(self.GetAttr("max_features_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public GradientBoostingRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyObject monitor = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				pyDict["monitor"] = ToPython(monitor);
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

			public GradientBoostingRegressor set_fit_request(string? monitor = "$UNCHANGED$", string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (monitor != null)
				{
					pyDict["monitor"] = ToPython(monitor);
				}
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public GradientBoostingRegressor set_params(PyDict? @params = null)
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

			public GradientBoostingRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class HistGradientBoostingClassifier : PythonObject
		{
			public HistGradientBoostingClassifier(string loss = "log_loss", float learning_rate = 0.1f, int max_iter = 100, int? max_leaf_nodes = 31, int? max_depth = null, int min_samples_leaf = 20, float l2_regularization = 0.0f, float max_features = 1.0f, int max_bins = 255, string? categorical_features = "warn", int? monotonic_cst = null, int? interaction_cst = null, bool warm_start = false, string early_stopping = "auto", string? scoring = "loss", float? validation_fraction = 0.1f, int n_iter_no_change = 10, float tol = 1e-07f, int verbose = 0, int? random_state = null, string? class_weight = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["loss"] = ToPython(loss);
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["max_iter"] = ToPython(max_iter);
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["l2_regularization"] = ToPython(l2_regularization);
				pyDict["max_features"] = ToPython(max_features);
				pyDict["max_bins"] = ToPython(max_bins);
				if (categorical_features != null)
				{
					pyDict["categorical_features"] = ToPython(categorical_features);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				if (interaction_cst != null)
				{
					pyDict["interaction_cst"] = ToPython(interaction_cst);
				}
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["early_stopping"] = ToPython(early_stopping);
				if (scoring != null)
				{
					pyDict["scoring"] = ToPython(scoring);
				}
				if (validation_fraction != null)
				{
					pyDict["validation_fraction"] = ToPython(validation_fraction);
				}
				pyDict["n_iter_no_change"] = ToPython(n_iter_no_change);
				pyDict["tol"] = ToPython(tol);
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				if (class_weight != null)
				{
					pyDict["class_weight"] = ToPython(class_weight);
				}
				self = sklearn.ensemble.self.InvokeMethod("HistGradientBoostingClassifier", args, pyDict);
			}

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public bool do_early_stopping_ => ToCsharp<bool>(self.GetAttr("do_early_stopping_"));

			public int n_trees_per_iteration_ => ToCsharp<int>(self.GetAttr("n_trees_per_iteration_"));

			public NDarray train_score_ => ToCsharp<NDarray>(self.GetAttr("train_score_"));

			public NDarray validation_score_ => ToCsharp<NDarray>(self.GetAttr("validation_score_"));

			public NDarray? is_categorical_ => ToCsharp<NDarray?>(self.GetAttr("is_categorical_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public HistGradientBoostingClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
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

			public HistGradientBoostingClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public HistGradientBoostingClassifier set_params(PyDict? @params = null)
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

			public HistGradientBoostingClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray staged_predict_proba(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict_proba", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class HistGradientBoostingRegressor : PythonObject
		{
			public HistGradientBoostingRegressor(string loss = "squared_error", float? quantile = null, float learning_rate = 0.1f, int max_iter = 100, int? max_leaf_nodes = 31, int? max_depth = null, int min_samples_leaf = 20, float l2_regularization = 0.0f, float max_features = 1.0f, int max_bins = 255, string? categorical_features = "warn", int? monotonic_cst = null, int? interaction_cst = null, bool warm_start = false, string early_stopping = "auto", string? scoring = "loss", float? validation_fraction = 0.1f, int n_iter_no_change = 10, float tol = 1e-07f, int verbose = 0, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["loss"] = ToPython(loss);
				if (quantile != null)
				{
					pyDict["quantile"] = ToPython(quantile);
				}
				pyDict["learning_rate"] = ToPython(learning_rate);
				pyDict["max_iter"] = ToPython(max_iter);
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["l2_regularization"] = ToPython(l2_regularization);
				pyDict["max_features"] = ToPython(max_features);
				pyDict["max_bins"] = ToPython(max_bins);
				if (categorical_features != null)
				{
					pyDict["categorical_features"] = ToPython(categorical_features);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				if (interaction_cst != null)
				{
					pyDict["interaction_cst"] = ToPython(interaction_cst);
				}
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["early_stopping"] = ToPython(early_stopping);
				if (scoring != null)
				{
					pyDict["scoring"] = ToPython(scoring);
				}
				if (validation_fraction != null)
				{
					pyDict["validation_fraction"] = ToPython(validation_fraction);
				}
				pyDict["n_iter_no_change"] = ToPython(n_iter_no_change);
				pyDict["tol"] = ToPython(tol);
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.ensemble.self.InvokeMethod("HistGradientBoostingRegressor", args, pyDict);
			}

			public bool do_early_stopping_ => ToCsharp<bool>(self.GetAttr("do_early_stopping_"));

			public int n_trees_per_iteration_ => ToCsharp<int>(self.GetAttr("n_trees_per_iteration_"));

			public NDarray train_score_ => ToCsharp<NDarray>(self.GetAttr("train_score_"));

			public NDarray validation_score_ => ToCsharp<NDarray>(self.GetAttr("validation_score_"));

			public NDarray? is_categorical_ => ToCsharp<NDarray?>(self.GetAttr("is_categorical_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public HistGradientBoostingRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public HistGradientBoostingRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public HistGradientBoostingRegressor set_params(PyDict? @params = null)
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

			public HistGradientBoostingRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public NDarray staged_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("staged_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class IsolationForest : PythonObject
		{
			public IsolationForest(int n_estimators = 100, string max_samples = "auto", string contamination = "auto", int max_features = 1, bool bootstrap = false, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["max_samples"] = ToPython(max_samples);
				pyDict["contamination"] = ToPython(contamination);
				pyDict["max_features"] = ToPython(max_features);
				pyDict["bootstrap"] = ToPython(bootstrap);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				self = sklearn.ensemble.self.InvokeMethod("IsolationForest", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray estimators_features_ => ToCsharp<NDarray>(self.GetAttr("estimators_features_"));

			public int max_samples_ => ToCsharp<int>(self.GetAttr("max_samples_"));

			public float offset_ => ToCsharp<float>(self.GetAttr("offset_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public IsolationForest fit(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray score_samples(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score_samples", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public IsolationForest set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public IsolationForest set_params(PyDict? @params = null)
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

		public class RandomForestClassifier : PythonObject
		{
			public RandomForestClassifier(int n_estimators = 100, string criterion = "gini", int? max_depth = null, float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, string? max_features = "sqrt", int? max_leaf_nodes = null, float min_impurity_decrease = 0.0f, bool bootstrap = true, bool oob_score = false, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false, string? class_weight = null, float ccp_alpha = 0.0f, int? max_samples = null, NDarray? monotonic_cst = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["criterion"] = ToPython(criterion);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["oob_score"] = ToPython(oob_score);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				if (class_weight != null)
				{
					pyDict["class_weight"] = ToPython(class_weight);
				}
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				if (max_samples != null)
				{
					pyDict["max_samples"] = ToPython(max_samples);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				self = sklearn.ensemble.self.InvokeMethod("RandomForestClassifier", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_classes_ => ToCsharp<int>(self.GetAttr("n_classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_outputs_ => ToCsharp<int>(self.GetAttr("n_outputs_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_decision_function_ => ToCsharp<NDarray>(self.GetAttr("oob_decision_function_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_path(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_path", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public RandomForestClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public RandomForestClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public RandomForestClassifier set_params(PyDict? @params = null)
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

			public RandomForestClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class RandomForestRegressor : PythonObject
		{
			public RandomForestRegressor(int n_estimators = 100, string criterion = "squared_error", int? max_depth = null, float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, int? max_features = 1, int? max_leaf_nodes = null, float min_impurity_decrease = 0.0f, bool bootstrap = true, bool oob_score = false, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false, float ccp_alpha = 0.0f, int? max_samples = null, NDarray? monotonic_cst = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["criterion"] = ToPython(criterion);
				if (max_depth != null)
				{
					pyDict["max_depth"] = ToPython(max_depth);
				}
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_features != null)
				{
					pyDict["max_features"] = ToPython(max_features);
				}
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				pyDict["bootstrap"] = ToPython(bootstrap);
				pyDict["oob_score"] = ToPython(oob_score);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				pyDict["ccp_alpha"] = ToPython(ccp_alpha);
				if (max_samples != null)
				{
					pyDict["max_samples"] = ToPython(max_samples);
				}
				if (monotonic_cst != null)
				{
					pyDict["monotonic_cst"] = ToPython(monotonic_cst);
				}
				self = sklearn.ensemble.self.InvokeMethod("RandomForestRegressor", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_outputs_ => ToCsharp<int>(self.GetAttr("n_outputs_"));

			public float oob_score_ => ToCsharp<float>(self.GetAttr("oob_score_"));

			public NDarray oob_prediction_ => ToCsharp<NDarray>(self.GetAttr("oob_prediction_"));

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_path(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_path", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public RandomForestRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public RandomForestRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public RandomForestRegressor set_params(PyDict? @params = null)
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

			public RandomForestRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class RandomTreesEmbedding : PythonObject
		{
			public RandomTreesEmbedding(int n_estimators = 100, int max_depth = 5, float min_samples_split = 2, float min_samples_leaf = 1, float min_weight_fraction_leaf = 0.0f, int? max_leaf_nodes = null, float min_impurity_decrease = 0.0f, bool sparse_output = true, int? n_jobs = null, int? random_state = null, int verbose = 0, bool warm_start = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_estimators"] = ToPython(n_estimators);
				pyDict["max_depth"] = ToPython(max_depth);
				pyDict["min_samples_split"] = ToPython(min_samples_split);
				pyDict["min_samples_leaf"] = ToPython(min_samples_leaf);
				pyDict["min_weight_fraction_leaf"] = ToPython(min_weight_fraction_leaf);
				if (max_leaf_nodes != null)
				{
					pyDict["max_leaf_nodes"] = ToPython(max_leaf_nodes);
				}
				pyDict["min_impurity_decrease"] = ToPython(min_impurity_decrease);
				pyDict["sparse_output"] = ToPython(sparse_output);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["warm_start"] = ToPython(warm_start);
				self = sklearn.ensemble.self.InvokeMethod("RandomTreesEmbedding", args, pyDict);
			}

			public PyObject estimator_ => self.GetAttr("estimator_");

			public PyObject estimators_ => self.GetAttr("estimators_");

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_outputs_ => ToCsharp<int>(self.GetAttr("n_outputs_"));

			public PyObject one_hot_encoder_ => self.GetAttr("one_hot_encoder_");

			public NDarray apply(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("apply", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray decision_path(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_path", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public RandomTreesEmbedding fit(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public RandomTreesEmbedding set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public RandomTreesEmbedding set_output(string? transform = null)
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

			public RandomTreesEmbedding set_params(PyDict? @params = null)
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

			public NDarray transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class StackingClassifier : PythonObject
		{
			public StackingClassifier(string estimators, PyObject final_estimator = null, int? cv = null, string stack_method = "auto", int? n_jobs = null, bool passthrough = false, int verbose = 0)
			{
				PyTuple args = ToTuple(new object[] {estimators});
				PyDict pyDict = new PyDict();
				pyDict["final_estimator"] = ToPython(final_estimator);
				if (cv != null)
				{
					pyDict["cv"] = ToPython(cv);
				}
				pyDict["stack_method"] = ToPython(stack_method);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["passthrough"] = ToPython(passthrough);
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("StackingClassifier", args, pyDict);
			}

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public PyObject estimators_ => self.GetAttr("estimators_");

			public PyObject named_estimators_ => self.GetAttr("named_estimators_");

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PyObject final_estimator_ => self.GetAttr("final_estimator_");

			public string stack_method_ => ToCsharp<string>(self.GetAttr("stack_method_"));

			public NDarray decision_function(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("decision_function", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public StackingClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public StackingClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public StackingClassifier set_output(string? transform = null)
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

			public StackingClassifier set_params(PyDict? @params = null)
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

			public StackingClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class StackingRegressor : PythonObject
		{
			public StackingRegressor(string estimators, PyObject final_estimator = null, int? cv = null, int? n_jobs = null, bool passthrough = false, int verbose = 0)
			{
				PyTuple args = ToTuple(new object[] {estimators});
				PyDict pyDict = new PyDict();
				pyDict["final_estimator"] = ToPython(final_estimator);
				if (cv != null)
				{
					pyDict["cv"] = ToPython(cv);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["passthrough"] = ToPython(passthrough);
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("StackingRegressor", args, pyDict);
			}

			public PyObject estimators_ => self.GetAttr("estimators_");

			public PyObject named_estimators_ => self.GetAttr("named_estimators_");

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PyObject final_estimator_ => self.GetAttr("final_estimator_");

			public string stack_method_ => ToCsharp<string>(self.GetAttr("stack_method_"));

			public StackingRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X, NDarray y, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public StackingRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public StackingRegressor set_output(string? transform = null)
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

			public StackingRegressor set_params(PyDict? @params = null)
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

			public StackingRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class VotingClassifier : PythonObject
		{
			public VotingClassifier(string estimators, string voting = "hard", NDarray? weights = null, int? n_jobs = null, bool flatten_transform = true, bool verbose = false)
			{
				PyTuple args = ToTuple(new object[] {estimators});
				PyDict pyDict = new PyDict();
				pyDict["voting"] = ToPython(voting);
				if (weights != null)
				{
					pyDict["weights"] = ToPython(weights);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["flatten_transform"] = ToPython(flatten_transform);
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("VotingClassifier", args, pyDict);
			}

			public PyObject estimators_ => self.GetAttr("estimators_");

			public PyObject named_estimators_ => self.GetAttr("named_estimators_");

			public PyObject le_ => self.GetAttr("le_");

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public VotingClassifier fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
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

			public VotingClassifier set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public VotingClassifier set_output(string? transform = null)
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

			public VotingClassifier set_params(PyDict? @params = null)
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

			public VotingClassifier set_score_request(string? sample_weight = "$UNCHANGED$")
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

			public PyObject transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return result;
			}

		}

		public class VotingRegressor : PythonObject
		{
			public VotingRegressor(string estimators, NDarray? weights = null, int? n_jobs = null, bool verbose = false)
			{
				PyTuple args = ToTuple(new object[] {estimators});
				PyDict pyDict = new PyDict();
				if (weights != null)
				{
					pyDict["weights"] = ToPython(weights);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.ensemble.self.InvokeMethod("VotingRegressor", args, pyDict);
			}

			public PyObject estimators_ => self.GetAttr("estimators_");

			public PyObject named_estimators_ => self.GetAttr("named_estimators_");

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public VotingRegressor fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X, y});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public VotingRegressor set_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_fit_request", args, pyDict);
				return this;
			}

			public VotingRegressor set_output(string? transform = null)
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

			public VotingRegressor set_params(PyDict? @params = null)
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

			public VotingRegressor set_score_request(string? sample_weight = "$UNCHANGED$")
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

	}
}
