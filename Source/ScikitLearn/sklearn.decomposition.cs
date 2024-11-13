using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class decomposition
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static decomposition() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.decomposition");
		}

		public class DictionaryLearning : PythonObject
		{
			public DictionaryLearning(int? n_components = null, float alpha = 1, int max_iter = 1000, float tol = 1e-08f, string fit_algorithm = "lars", string transform_algorithm = "omp", int? transform_n_nonzero_coefs = null, float? transform_alpha = null, int? n_jobs = null, NDarray? code_init = null, NDarray? dict_init = null, PyObject callback = null, bool verbose = false, bool split_sign = false, int? random_state = null, bool positive_code = false, bool positive_dict = false, int transform_max_iter = 1000)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["alpha"] = ToPython(alpha);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["fit_algorithm"] = ToPython(fit_algorithm);
				pyDict["transform_algorithm"] = ToPython(transform_algorithm);
				if (transform_n_nonzero_coefs != null)
				{
					pyDict["transform_n_nonzero_coefs"] = ToPython(transform_n_nonzero_coefs);
				}
				if (transform_alpha != null)
				{
					pyDict["transform_alpha"] = ToPython(transform_alpha);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (code_init != null)
				{
					pyDict["code_init"] = ToPython(code_init);
				}
				if (dict_init != null)
				{
					pyDict["dict_init"] = ToPython(dict_init);
				}
				pyDict["callback"] = ToPython(callback);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["split_sign"] = ToPython(split_sign);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["positive_code"] = ToPython(positive_code);
				pyDict["positive_dict"] = ToPython(positive_dict);
				pyDict["transform_max_iter"] = ToPython(transform_max_iter);
				self = sklearn.decomposition.self.InvokeMethod("DictionaryLearning", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray error_ => ToCsharp<NDarray>(self.GetAttr("error_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public DictionaryLearning fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public DictionaryLearning set_output(string? transform = null)
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

			public DictionaryLearning set_params(PyDict? @params = null)
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

		public class FactorAnalysis : PythonObject
		{
			public FactorAnalysis(int? n_components = null, float tol = 0.01f, bool copy = true, int max_iter = 1000, NDarray? noise_variance_init = null, string svd_method = "randomized", int iterated_power = 3, string? rotation = null, int random_state = 0)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["copy"] = ToPython(copy);
				pyDict["max_iter"] = ToPython(max_iter);
				if (noise_variance_init != null)
				{
					pyDict["noise_variance_init"] = ToPython(noise_variance_init);
				}
				pyDict["svd_method"] = ToPython(svd_method);
				pyDict["iterated_power"] = ToPython(iterated_power);
				if (rotation != null)
				{
					pyDict["rotation"] = ToPython(rotation);
				}
				pyDict["random_state"] = ToPython(random_state);
				self = sklearn.decomposition.self.InvokeMethod("FactorAnalysis", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray loglike_ => ToCsharp<NDarray>(self.GetAttr("loglike_"));

			public NDarray noise_variance_ => ToCsharp<NDarray>(self.GetAttr("noise_variance_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public FactorAnalysis fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_covariance()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_covariance", args, pyDict);
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public FactorAnalysis set_output(string? transform = null)
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

			public FactorAnalysis set_params(PyDict? @params = null)
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

		public class FastICA : PythonObject
		{
			public FastICA(int? n_components = null, string algorithm = "parallel", string whiten = "unit-variance", string fun = "logcosh", PyObject fun_args = null, int max_iter = 200, float tol = 0.0001f, NDarray? w_init = null, string whiten_solver = "svd", int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["whiten"] = ToPython(whiten);
				pyDict["fun"] = ToPython(fun);
				pyDict["fun_args"] = ToPython(fun_args);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				if (w_init != null)
				{
					pyDict["w_init"] = ToPython(w_init);
				}
				pyDict["whiten_solver"] = ToPython(whiten_solver);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.decomposition.self.InvokeMethod("FastICA", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray mixing_ => ToCsharp<NDarray>(self.GetAttr("mixing_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public NDarray whitening_ => ToCsharp<NDarray>(self.GetAttr("whitening_"));

			public FastICA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public NDarray inverse_transform(NDarray X, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["copy"] = ToPython(copy);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public FastICA set_inverse_transform_request(string? copy = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (copy != null)
				{
					pyDict["copy"] = ToPython(copy);
				}
				self.InvokeMethod("set_inverse_transform_request", args, pyDict);
				return this;
			}

			public FastICA set_output(string? transform = null)
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

			public FastICA set_params(PyDict? @params = null)
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

			public FastICA set_transform_request(string? copy = "$UNCHANGED$")
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

			public NDarray transform(NDarray X, bool copy = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["copy"] = ToPython(copy);
				PyObject result = self.InvokeMethod("transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

		}

		public class IncrementalPCA : PythonObject
		{
			public IncrementalPCA(int? n_components = null, bool whiten = false, bool copy = true, int? batch_size = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["whiten"] = ToPython(whiten);
				pyDict["copy"] = ToPython(copy);
				if (batch_size != null)
				{
					pyDict["batch_size"] = ToPython(batch_size);
				}
				self = sklearn.decomposition.self.InvokeMethod("IncrementalPCA", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray explained_variance_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_"));

			public NDarray explained_variance_ratio_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_ratio_"));

			public NDarray singular_values_ => ToCsharp<NDarray>(self.GetAttr("singular_values_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public NDarray var_ => ToCsharp<NDarray>(self.GetAttr("var_"));

			public float noise_variance_ => ToCsharp<float>(self.GetAttr("noise_variance_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public int n_samples_seen_ => ToCsharp<int>(self.GetAttr("n_samples_seen_"));

			public int batch_size_ => ToCsharp<int>(self.GetAttr("batch_size_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public IncrementalPCA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray get_covariance()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_covariance", args, pyDict);
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public IncrementalPCA partial_fit(NDarray X, bool check_input = true)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["check_input"] = ToPython(check_input);
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public IncrementalPCA set_output(string? transform = null)
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

			public IncrementalPCA set_params(PyDict? @params = null)
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

			public IncrementalPCA set_partial_fit_request(string? check_input = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (check_input != null)
				{
					pyDict["check_input"] = ToPython(check_input);
				}
				self.InvokeMethod("set_partial_fit_request", args, pyDict);
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

		public class KernelPCA : PythonObject
		{
			public KernelPCA(int? n_components = null, string kernel = "linear", float? gamma = null, float degree = 3, float coef0 = 1, PyObject kernel_params = null, float alpha = 1.0f, bool fit_inverse_transform = false, string eigen_solver = "auto", float tol = 0, int? max_iter = null, string iterated_power = "auto", bool remove_zero_eig = false, int? random_state = null, bool copy_X = true, int? n_jobs = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["kernel"] = ToPython(kernel);
				if (gamma != null)
				{
					pyDict["gamma"] = ToPython(gamma);
				}
				pyDict["degree"] = ToPython(degree);
				pyDict["coef0"] = ToPython(coef0);
				pyDict["kernel_params"] = ToPython(kernel_params);
				pyDict["alpha"] = ToPython(alpha);
				pyDict["fit_inverse_transform"] = ToPython(fit_inverse_transform);
				pyDict["eigen_solver"] = ToPython(eigen_solver);
				pyDict["tol"] = ToPython(tol);
				if (max_iter != null)
				{
					pyDict["max_iter"] = ToPython(max_iter);
				}
				pyDict["iterated_power"] = ToPython(iterated_power);
				pyDict["remove_zero_eig"] = ToPython(remove_zero_eig);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["copy_X"] = ToPython(copy_X);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				self = sklearn.decomposition.self.InvokeMethod("KernelPCA", args, pyDict);
			}

			public NDarray eigenvalues_ => ToCsharp<NDarray>(self.GetAttr("eigenvalues_"));

			public NDarray eigenvectors_ => ToCsharp<NDarray>(self.GetAttr("eigenvectors_"));

			public NDarray dual_coef_ => ToCsharp<NDarray>(self.GetAttr("dual_coef_"));

			public NDarray X_transformed_fit_ => ToCsharp<NDarray>(self.GetAttr("X_transformed_fit_"));

			public NDarray X_fit_ => ToCsharp<NDarray>(self.GetAttr("X_fit_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public float gamma_ => ToCsharp<float>(self.GetAttr("gamma_"));

			public KernelPCA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X, PyDict? @params = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public KernelPCA set_output(string? transform = null)
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

			public KernelPCA set_params(PyDict? @params = null)
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

		public class LatentDirichletAllocation : PythonObject
		{
			public LatentDirichletAllocation(int n_components = 10, float? doc_topic_prior = null, float? topic_word_prior = null, string learning_method = "batch", float learning_decay = 0.7f, float learning_offset = 10.0f, int max_iter = 10, int batch_size = 128, int evaluate_every = -1, float total_samples = 1000000.0f, float perp_tol = 0.1f, float mean_change_tol = 0.001f, int max_doc_update_iter = 100, int? n_jobs = null, int verbose = 0, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				if (doc_topic_prior != null)
				{
					pyDict["doc_topic_prior"] = ToPython(doc_topic_prior);
				}
				if (topic_word_prior != null)
				{
					pyDict["topic_word_prior"] = ToPython(topic_word_prior);
				}
				pyDict["learning_method"] = ToPython(learning_method);
				pyDict["learning_decay"] = ToPython(learning_decay);
				pyDict["learning_offset"] = ToPython(learning_offset);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["batch_size"] = ToPython(batch_size);
				pyDict["evaluate_every"] = ToPython(evaluate_every);
				pyDict["total_samples"] = ToPython(total_samples);
				pyDict["perp_tol"] = ToPython(perp_tol);
				pyDict["mean_change_tol"] = ToPython(mean_change_tol);
				pyDict["max_doc_update_iter"] = ToPython(max_doc_update_iter);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.decomposition.self.InvokeMethod("LatentDirichletAllocation", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray exp_dirichlet_component_ => ToCsharp<NDarray>(self.GetAttr("exp_dirichlet_component_"));

			public int n_batch_iter_ => ToCsharp<int>(self.GetAttr("n_batch_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public float bound_ => ToCsharp<float>(self.GetAttr("bound_"));

			public float doc_topic_prior_ => ToCsharp<float>(self.GetAttr("doc_topic_prior_"));

			public PyObject random_state_ => self.GetAttr("random_state_");

			public float topic_word_prior_ => ToCsharp<float>(self.GetAttr("topic_word_prior_"));

			public LatentDirichletAllocation fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public LatentDirichletAllocation partial_fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public float perplexity(NDarray X, bool sub_sampling = false)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["sub_sampling"] = ToPython(sub_sampling);
				PyObject result = self.InvokeMethod("perplexity", args, pyDict);
				return ToCsharp<float>(result);
			}

			public float score(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public LatentDirichletAllocation set_output(string? transform = null)
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

			public LatentDirichletAllocation set_params(PyDict? @params = null)
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

		public class MiniBatchDictionaryLearning : PythonObject
		{
			public MiniBatchDictionaryLearning(int? n_components = null, float alpha = 1, int max_iter = 1000, string fit_algorithm = "lars", int? n_jobs = null, int batch_size = 256, bool shuffle = true, NDarray? dict_init = null, string transform_algorithm = "omp", int? transform_n_nonzero_coefs = null, float? transform_alpha = null, bool verbose = false, bool split_sign = false, int? random_state = null, bool positive_code = false, bool positive_dict = false, int transform_max_iter = 1000, PyObject callback = null, float tol = 0.001f, int max_no_improvement = 10)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["alpha"] = ToPython(alpha);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["fit_algorithm"] = ToPython(fit_algorithm);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["batch_size"] = ToPython(batch_size);
				pyDict["shuffle"] = ToPython(shuffle);
				if (dict_init != null)
				{
					pyDict["dict_init"] = ToPython(dict_init);
				}
				pyDict["transform_algorithm"] = ToPython(transform_algorithm);
				if (transform_n_nonzero_coefs != null)
				{
					pyDict["transform_n_nonzero_coefs"] = ToPython(transform_n_nonzero_coefs);
				}
				if (transform_alpha != null)
				{
					pyDict["transform_alpha"] = ToPython(transform_alpha);
				}
				pyDict["verbose"] = ToPython(verbose);
				pyDict["split_sign"] = ToPython(split_sign);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["positive_code"] = ToPython(positive_code);
				pyDict["positive_dict"] = ToPython(positive_dict);
				pyDict["transform_max_iter"] = ToPython(transform_max_iter);
				pyDict["callback"] = ToPython(callback);
				pyDict["tol"] = ToPython(tol);
				pyDict["max_no_improvement"] = ToPython(max_no_improvement);
				self = sklearn.decomposition.self.InvokeMethod("MiniBatchDictionaryLearning", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_steps_ => ToCsharp<int>(self.GetAttr("n_steps_"));

			public MiniBatchDictionaryLearning fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public MiniBatchDictionaryLearning partial_fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public MiniBatchDictionaryLearning set_output(string? transform = null)
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

			public MiniBatchDictionaryLearning set_params(PyDict? @params = null)
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

		public class MiniBatchNMF : PythonObject
		{
			public MiniBatchNMF(string? n_components = "warn", string? init = null, int batch_size = 1024, string beta_loss = "frobenius", float tol = 0.0001f, int max_no_improvement = 10, int max_iter = 200, float alpha_W = 0.0f, string alpha_H = "same", float l1_ratio = 0.0f, float forget_factor = 0.7f, bool fresh_restarts = false, int fresh_restarts_max_iter = 30, int? transform_max_iter = null, int? random_state = null, int verbose = 0)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				if (init != null)
				{
					pyDict["init"] = ToPython(init);
				}
				pyDict["batch_size"] = ToPython(batch_size);
				pyDict["beta_loss"] = ToPython(beta_loss);
				pyDict["tol"] = ToPython(tol);
				pyDict["max_no_improvement"] = ToPython(max_no_improvement);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["alpha_W"] = ToPython(alpha_W);
				pyDict["alpha_H"] = ToPython(alpha_H);
				pyDict["l1_ratio"] = ToPython(l1_ratio);
				pyDict["forget_factor"] = ToPython(forget_factor);
				pyDict["fresh_restarts"] = ToPython(fresh_restarts);
				pyDict["fresh_restarts_max_iter"] = ToPython(fresh_restarts_max_iter);
				if (transform_max_iter != null)
				{
					pyDict["transform_max_iter"] = ToPython(transform_max_iter);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.decomposition.self.InvokeMethod("MiniBatchNMF", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public float reconstruction_err_ => ToCsharp<float>(self.GetAttr("reconstruction_err_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_steps_ => ToCsharp<int>(self.GetAttr("n_steps_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public MiniBatchNMF fit(NDarray X, PyDict? @params = null)
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

			public NDarray fit_transform(NDarray X, NDarray? W = null, NDarray? H = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (W != null)
				{
					pyDict["W"] = ToPython(W);
				}
				if (H != null)
				{
					pyDict["H"] = ToPython(H);
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

			public NDarray inverse_transform(NDarray X = null, NDarray Xt = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["X"] = ToPython(X);
				pyDict["Xt"] = ToPython(Xt);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public MiniBatchNMF partial_fit(NDarray X, NDarray? W = null, NDarray? H = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (W != null)
				{
					pyDict["W"] = ToPython(W);
				}
				if (H != null)
				{
					pyDict["H"] = ToPython(H);
				}
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public MiniBatchNMF set_output(string? transform = null)
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

			public MiniBatchNMF set_params(PyDict? @params = null)
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

		public class MiniBatchSparsePCA : PythonObject
		{
			public MiniBatchSparsePCA(int? n_components = null, int alpha = 1, float ridge_alpha = 0.01f, int max_iter = 1000, PyObject callback = null, int batch_size = 3, bool verbose = false, bool shuffle = true, int? n_jobs = null, string method = "lars", int? random_state = null, float tol = 0.001f, int? max_no_improvement = 10)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["alpha"] = ToPython(alpha);
				pyDict["ridge_alpha"] = ToPython(ridge_alpha);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["callback"] = ToPython(callback);
				pyDict["batch_size"] = ToPython(batch_size);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["shuffle"] = ToPython(shuffle);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["method"] = ToPython(method);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["tol"] = ToPython(tol);
				if (max_no_improvement != null)
				{
					pyDict["max_no_improvement"] = ToPython(max_no_improvement);
				}
				self = sklearn.decomposition.self.InvokeMethod("MiniBatchSparsePCA", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public MiniBatchSparsePCA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public MiniBatchSparsePCA set_output(string? transform = null)
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

			public MiniBatchSparsePCA set_params(PyDict? @params = null)
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

		public class NMF : PythonObject
		{
			public NMF(string? n_components = "warn", string? init = null, string solver = "cd", string beta_loss = "frobenius", float tol = 0.0001f, int max_iter = 200, int? random_state = null, float alpha_W = 0.0f, string alpha_H = "same", float l1_ratio = 0.0f, int verbose = 0, bool shuffle = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				if (init != null)
				{
					pyDict["init"] = ToPython(init);
				}
				pyDict["solver"] = ToPython(solver);
				pyDict["beta_loss"] = ToPython(beta_loss);
				pyDict["tol"] = ToPython(tol);
				pyDict["max_iter"] = ToPython(max_iter);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["alpha_W"] = ToPython(alpha_W);
				pyDict["alpha_H"] = ToPython(alpha_H);
				pyDict["l1_ratio"] = ToPython(l1_ratio);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["shuffle"] = ToPython(shuffle);
				self = sklearn.decomposition.self.InvokeMethod("NMF", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public float reconstruction_err_ => ToCsharp<float>(self.GetAttr("reconstruction_err_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NMF fit(NDarray X, PyDict? @params = null)
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

			public NDarray fit_transform(NDarray X, NDarray? W = null, NDarray? H = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (W != null)
				{
					pyDict["W"] = ToPython(W);
				}
				if (H != null)
				{
					pyDict["H"] = ToPython(H);
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

			public NDarray inverse_transform(NDarray X = null, NDarray Xt = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["X"] = ToPython(X);
				pyDict["Xt"] = ToPython(Xt);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NMF set_output(string? transform = null)
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

			public NMF set_params(PyDict? @params = null)
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

		public class PCA : PythonObject
		{
			public PCA(int? n_components = null, bool copy = true, bool whiten = false, string svd_solver = "auto", float tol = 0.0f, string iterated_power = "auto", int n_oversamples = 10, string? power_iteration_normalizer = "auto", int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["copy"] = ToPython(copy);
				pyDict["whiten"] = ToPython(whiten);
				pyDict["svd_solver"] = ToPython(svd_solver);
				pyDict["tol"] = ToPython(tol);
				pyDict["iterated_power"] = ToPython(iterated_power);
				pyDict["n_oversamples"] = ToPython(n_oversamples);
				if (power_iteration_normalizer != null)
				{
					pyDict["power_iteration_normalizer"] = ToPython(power_iteration_normalizer);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.decomposition.self.InvokeMethod("PCA", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray explained_variance_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_"));

			public NDarray explained_variance_ratio_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_ratio_"));

			public NDarray singular_values_ => ToCsharp<NDarray>(self.GetAttr("singular_values_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public int n_samples_ => ToCsharp<int>(self.GetAttr("n_samples_"));

			public float noise_variance_ => ToCsharp<float>(self.GetAttr("noise_variance_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public PCA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("fit_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray get_covariance()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_covariance", args, pyDict);
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

			public NDarray get_precision()
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_precision", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public PCA set_output(string? transform = null)
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

			public PCA set_params(PyDict? @params = null)
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

		public class SparseCoder : PythonObject
		{
			public SparseCoder(NDarray dictionary, string transform_algorithm = "omp", int? transform_n_nonzero_coefs = null, float? transform_alpha = null, bool split_sign = false, int? n_jobs = null, bool positive_code = false, int transform_max_iter = 1000)
			{
				PyTuple args = ToTuple(new object[] {dictionary});
				PyDict pyDict = new PyDict();
				pyDict["transform_algorithm"] = ToPython(transform_algorithm);
				if (transform_n_nonzero_coefs != null)
				{
					pyDict["transform_n_nonzero_coefs"] = ToPython(transform_n_nonzero_coefs);
				}
				if (transform_alpha != null)
				{
					pyDict["transform_alpha"] = ToPython(transform_alpha);
				}
				pyDict["split_sign"] = ToPython(split_sign);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["positive_code"] = ToPython(positive_code);
				pyDict["transform_max_iter"] = ToPython(transform_max_iter);
				self = sklearn.decomposition.self.InvokeMethod("SparseCoder", args, pyDict);
			}

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public SparseCoder fit()
			{
				PyTuple args = new PyTuple();
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

			public SparseCoder set_output(string? transform = null)
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

			public SparseCoder set_params(PyDict? @params = null)
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

		public class SparsePCA : PythonObject
		{
			public SparsePCA(int? n_components = null, float alpha = 1, float ridge_alpha = 0.01f, int max_iter = 1000, float tol = 1e-08f, string method = "lars", int? n_jobs = null, NDarray? U_init = null, NDarray? V_init = null, bool verbose = false, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				pyDict["alpha"] = ToPython(alpha);
				pyDict["ridge_alpha"] = ToPython(ridge_alpha);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["method"] = ToPython(method);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				if (U_init != null)
				{
					pyDict["U_init"] = ToPython(U_init);
				}
				if (V_init != null)
				{
					pyDict["V_init"] = ToPython(V_init);
				}
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.decomposition.self.InvokeMethod("SparsePCA", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray error_ => ToCsharp<NDarray>(self.GetAttr("error_"));

			public int n_components_ => ToCsharp<int>(self.GetAttr("n_components_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public NDarray mean_ => ToCsharp<NDarray>(self.GetAttr("mean_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public SparsePCA fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
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

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public SparsePCA set_output(string? transform = null)
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

			public SparsePCA set_params(PyDict? @params = null)
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

		public class TruncatedSVD : PythonObject
		{
			public TruncatedSVD(int n_components = 2, string algorithm = "randomized", int n_iter = 5, int n_oversamples = 10, string? power_iteration_normalizer = "auto", int? random_state = null, float tol = 0.0f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_components"] = ToPython(n_components);
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["n_iter"] = ToPython(n_iter);
				pyDict["n_oversamples"] = ToPython(n_oversamples);
				if (power_iteration_normalizer != null)
				{
					pyDict["power_iteration_normalizer"] = ToPython(power_iteration_normalizer);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["tol"] = ToPython(tol);
				self = sklearn.decomposition.self.InvokeMethod("TruncatedSVD", args, pyDict);
			}

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray explained_variance_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_"));

			public NDarray explained_variance_ratio_ => ToCsharp<NDarray>(self.GetAttr("explained_variance_ratio_"));

			public NDarray singular_values_ => ToCsharp<NDarray>(self.GetAttr("singular_values_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public TruncatedSVD fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public NDarray inverse_transform(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public TruncatedSVD set_output(string? transform = null)
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

			public TruncatedSVD set_params(PyDict? @params = null)
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

	}
}
