using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class calibration
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static calibration() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.calibration");
		}

		public class CalibratedClassifierCV : PythonObject
		{
			public CalibratedClassifierCV(PyObject estimator = null, string method = "sigmoid", int? cv = null, int? n_jobs = null, bool ensemble = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["estimator"] = ToPython(estimator);
				pyDict["method"] = ToPython(method);
				if (cv != null)
				{
					pyDict["cv"] = ToPython(cv);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["ensemble"] = ToPython(ensemble);
				self = sklearn.calibration.self.InvokeMethod("CalibratedClassifierCV", args, pyDict);
			}

			public NDarray classes_ => ToCsharp<NDarray>(self.GetAttr("classes_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public bool calibrated_classifiers_ => ToCsharp<bool>(self.GetAttr("calibrated_classifiers_"));

			public CalibratedClassifierCV fit(NDarray X, NDarray y, NDarray? sample_weight = null, PyDict? @params = null)
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

			public CalibratedClassifierCV set_fit_request(string? sample_weight = "$UNCHANGED$")
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

			public CalibratedClassifierCV set_params(PyDict? @params = null)
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

			public CalibratedClassifierCV set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class CalibrationDisplay : PythonObject
		{
			public CalibrationDisplay(NDarray prob_true, NDarray prob_pred, NDarray y_prob, string? estimator_name = null, bool? pos_label = null)
			{
				PyTuple args = ToTuple(new object[] {prob_true, prob_pred, y_prob});
				PyDict pyDict = new PyDict();
				if (estimator_name != null)
				{
					pyDict["estimator_name"] = ToPython(estimator_name);
				}
				if (pos_label != null)
				{
					pyDict["pos_label"] = ToPython(pos_label);
				}
				self = sklearn.calibration.self.InvokeMethod("CalibrationDisplay", args, pyDict);
			}

			public PyObject line_ => self.GetAttr("line_");

			public PyObject ax_ => self.GetAttr("ax_");

			public PyObject figure_ => self.GetAttr("figure_");

			public PyObject from_estimator(PyObject estimator, NDarray X, NDarray y, int n_bins = 5, string strategy = "uniform", bool? pos_label = null, string? name = null, bool ref_line = true, PyObject ax = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {estimator, X, y});
				PyDict pyDict = new PyDict();
				pyDict["n_bins"] = ToPython(n_bins);
				pyDict["strategy"] = ToPython(strategy);
				if (pos_label != null)
				{
					pyDict["pos_label"] = ToPython(pos_label);
				}
				if (name != null)
				{
					pyDict["name"] = ToPython(name);
				}
				pyDict["ref_line"] = ToPython(ref_line);
				pyDict["ax"] = ToPython(ax);
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("from_estimator", args, pyDict);
				return result;
			}

			public PyObject from_predictions(NDarray y_true, NDarray y_prob, int n_bins = 5, string strategy = "uniform", bool? pos_label = null, string? name = null, bool ref_line = true, PyObject ax = null, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {y_true, y_prob});
				PyDict pyDict = new PyDict();
				pyDict["n_bins"] = ToPython(n_bins);
				pyDict["strategy"] = ToPython(strategy);
				if (pos_label != null)
				{
					pyDict["pos_label"] = ToPython(pos_label);
				}
				if (name != null)
				{
					pyDict["name"] = ToPython(name);
				}
				pyDict["ref_line"] = ToPython(ref_line);
				pyDict["ax"] = ToPython(ax);
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("from_predictions", args, pyDict);
				return result;
			}

			public PyObject plot(PyObject ax = null, string? name = null, bool ref_line = true, PyDict? @params = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["ax"] = ToPython(ax);
				if (name != null)
				{
					pyDict["name"] = ToPython(name);
				}
				pyDict["ref_line"] = ToPython(ref_line);
				if (@params != null)
				{
					pyDict["@params"] = ToPython(@params);
				}
				PyObject result = self.InvokeMethod("plot", args, pyDict);
				return result;
			}

		}

	}
}
