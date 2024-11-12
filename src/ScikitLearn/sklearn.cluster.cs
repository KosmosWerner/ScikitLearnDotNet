using Numpy;
using Python.Runtime;

namespace ScikitLearn;

public static partial class sklearn
{
	public static class cluster
	{
		private static Lazy<PyObject> _lazy_self;

		public static PyObject self => _lazy_self.Value;

		static cluster() => ReInitializeLazySelf();

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
			return Py.Import("sklearn.cluster");
		}

		public class AffinityPropagation : PythonObject
		{
			public AffinityPropagation(float damping = 0.5f, int max_iter = 200, int convergence_iter = 15, bool copy = true, float? preference = null, string affinity = "euclidean", bool verbose = false, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["damping"] = ToPython(damping);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["convergence_iter"] = ToPython(convergence_iter);
				pyDict["copy"] = ToPython(copy);
				if (preference != null)
				{
					pyDict["preference"] = ToPython(preference);
				}
				pyDict["affinity"] = ToPython(affinity);
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.cluster.self.InvokeMethod("AffinityPropagation", args, pyDict);
			}

			public NDarray cluster_centers_indices_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_indices_"));

			public NDarray cluster_centers_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public NDarray affinity_matrix_ => ToCsharp<NDarray>(self.GetAttr("affinity_matrix_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public AffinityPropagation fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public AffinityPropagation set_params(PyDict? @params = null)
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

		public class AgglomerativeClustering : PythonObject
		{
			public AgglomerativeClustering(int? n_clusters = 2, string metric = "euclidean", int? memory = null, NDarray? connectivity = null, string compute_full_tree = "auto", string linkage = "ward", float? distance_threshold = null, bool compute_distances = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_clusters != null)
				{
					pyDict["n_clusters"] = ToPython(n_clusters);
				}
				pyDict["metric"] = ToPython(metric);
				if (memory != null)
				{
					pyDict["memory"] = ToPython(memory);
				}
				if (connectivity != null)
				{
					pyDict["connectivity"] = ToPython(connectivity);
				}
				pyDict["compute_full_tree"] = ToPython(compute_full_tree);
				pyDict["linkage"] = ToPython(linkage);
				if (distance_threshold != null)
				{
					pyDict["distance_threshold"] = ToPython(distance_threshold);
				}
				pyDict["compute_distances"] = ToPython(compute_distances);
				self = sklearn.cluster.self.InvokeMethod("AgglomerativeClustering", args, pyDict);
			}

			public int n_clusters_ => ToCsharp<int>(self.GetAttr("n_clusters_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_leaves_ => ToCsharp<int>(self.GetAttr("n_leaves_"));

			public int n_connected_components_ => ToCsharp<int>(self.GetAttr("n_connected_components_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray children_ => ToCsharp<NDarray>(self.GetAttr("children_"));

			public NDarray distances_ => ToCsharp<NDarray>(self.GetAttr("distances_"));

			public AgglomerativeClustering fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public AgglomerativeClustering set_params(PyDict? @params = null)
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

		public class Birch : PythonObject
		{
			public Birch(float threshold = 0.5f, int branching_factor = 50, int? n_clusters = 3, bool compute_labels = true, bool copy = true)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["threshold"] = ToPython(threshold);
				pyDict["branching_factor"] = ToPython(branching_factor);
				if (n_clusters != null)
				{
					pyDict["n_clusters"] = ToPython(n_clusters);
				}
				pyDict["compute_labels"] = ToPython(compute_labels);
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cluster.self.InvokeMethod("Birch", args, pyDict);
			}

			public PyObject root_ => self.GetAttr("root_");

			public PyObject dummy_leaf_ => self.GetAttr("dummy_leaf_");

			public NDarray subcluster_centers_ => ToCsharp<NDarray>(self.GetAttr("subcluster_centers_"));

			public NDarray subcluster_labels_ => ToCsharp<NDarray>(self.GetAttr("subcluster_labels_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public Birch fit(NDarray X)
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

			public Birch partial_fit(NDarray? X = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (X != null)
				{
					pyDict["X"] = ToPython(X);
				}
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public Birch set_output(string? transform = null)
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

			public Birch set_params(PyDict? @params = null)
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

		public class BisectingKMeans : PythonObject
		{
			public BisectingKMeans(int n_clusters = 8, string init = "random", int n_init = 1, int? random_state = null, int max_iter = 300, int verbose = 0, float tol = 0.0001f, bool copy_x = true, string algorithm = "lloyd", string bisecting_strategy = "biggest_inertia")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				pyDict["init"] = ToPython(init);
				pyDict["n_init"] = ToPython(n_init);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["tol"] = ToPython(tol);
				pyDict["copy_x"] = ToPython(copy_x);
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["bisecting_strategy"] = ToPython(bisecting_strategy);
				self = sklearn.cluster.self.InvokeMethod("BisectingKMeans", args, pyDict);
			}

			public NDarray cluster_centers_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public float inertia_ => ToCsharp<float>(self.GetAttr("inertia_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public BisectingKMeans fit(NDarray X, NDarray? sample_weight = null)
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

			public NDarray fit_predict(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("fit_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public BisectingKMeans set_fit_request(string? sample_weight = "$UNCHANGED$")
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

			public BisectingKMeans set_output(string? transform = null)
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

			public BisectingKMeans set_params(PyDict? @params = null)
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

			public BisectingKMeans set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class DBSCAN : PythonObject
		{
			public DBSCAN(float eps = 0.5f, int min_samples = 5, string metric = "euclidean", PyObject metric_params = null, string algorithm = "auto", int leaf_size = 30, float? p = null, int? n_jobs = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["eps"] = ToPython(eps);
				pyDict["min_samples"] = ToPython(min_samples);
				pyDict["metric"] = ToPython(metric);
				pyDict["metric_params"] = ToPython(metric_params);
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["leaf_size"] = ToPython(leaf_size);
				if (p != null)
				{
					pyDict["p"] = ToPython(p);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				self = sklearn.cluster.self.InvokeMethod("DBSCAN", args, pyDict);
			}

			public NDarray core_sample_indices_ => ToCsharp<NDarray>(self.GetAttr("core_sample_indices_"));

			public NDarray components_ => ToCsharp<NDarray>(self.GetAttr("components_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public DBSCAN fit(NDarray X, NDarray? sample_weight = null)
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

			public NDarray fit_predict(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
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

			public DBSCAN set_fit_request(string? sample_weight = "$UNCHANGED$")
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

			public DBSCAN set_params(PyDict? @params = null)
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

		public class FeatureAgglomeration : PythonObject
		{
			public FeatureAgglomeration(int? n_clusters = 2, string metric = "euclidean", int? memory = null, NDarray? connectivity = null, string compute_full_tree = "auto", string linkage = "ward", PyObject pooling_func = null, float? distance_threshold = null, bool compute_distances = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (n_clusters != null)
				{
					pyDict["n_clusters"] = ToPython(n_clusters);
				}
				pyDict["metric"] = ToPython(metric);
				if (memory != null)
				{
					pyDict["memory"] = ToPython(memory);
				}
				if (connectivity != null)
				{
					pyDict["connectivity"] = ToPython(connectivity);
				}
				pyDict["compute_full_tree"] = ToPython(compute_full_tree);
				pyDict["linkage"] = ToPython(linkage);
				pyDict["pooling_func"] = ToPython(pooling_func);
				if (distance_threshold != null)
				{
					pyDict["distance_threshold"] = ToPython(distance_threshold);
				}
				pyDict["compute_distances"] = ToPython(compute_distances);
				self = sklearn.cluster.self.InvokeMethod("FeatureAgglomeration", args, pyDict);
			}

			public int n_clusters_ => ToCsharp<int>(self.GetAttr("n_clusters_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_leaves_ => ToCsharp<int>(self.GetAttr("n_leaves_"));

			public int n_connected_components_ => ToCsharp<int>(self.GetAttr("n_connected_components_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray children_ => ToCsharp<NDarray>(self.GetAttr("children_"));

			public NDarray distances_ => ToCsharp<NDarray>(self.GetAttr("distances_"));

			public FeatureAgglomeration fit(NDarray X)
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

			public NDarray inverse_transform(NDarray X = null, NDarray Xt = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["X"] = ToPython(X);
				pyDict["Xt"] = ToPython(Xt);
				PyObject result = self.InvokeMethod("inverse_transform", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public FeatureAgglomeration set_output(string? transform = null)
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

			public FeatureAgglomeration set_params(PyDict? @params = null)
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

		public class HDBSCAN : PythonObject
		{
			public HDBSCAN(int min_cluster_size = 5, int? min_samples = null, float cluster_selection_epsilon = 0.0f, int? max_cluster_size = null, string metric = "euclidean", PyObject metric_params = null, float alpha = 1.0f, string algorithm = "auto", int leaf_size = 40, int? n_jobs = null, string cluster_selection_method = "eom", bool allow_single_cluster = false, string? store_centers = null, bool copy = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["min_cluster_size"] = ToPython(min_cluster_size);
				if (min_samples != null)
				{
					pyDict["min_samples"] = ToPython(min_samples);
				}
				pyDict["cluster_selection_epsilon"] = ToPython(cluster_selection_epsilon);
				if (max_cluster_size != null)
				{
					pyDict["max_cluster_size"] = ToPython(max_cluster_size);
				}
				pyDict["metric"] = ToPython(metric);
				pyDict["metric_params"] = ToPython(metric_params);
				pyDict["alpha"] = ToPython(alpha);
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["leaf_size"] = ToPython(leaf_size);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["cluster_selection_method"] = ToPython(cluster_selection_method);
				pyDict["allow_single_cluster"] = ToPython(allow_single_cluster);
				if (store_centers != null)
				{
					pyDict["store_centers"] = ToPython(store_centers);
				}
				pyDict["copy"] = ToPython(copy);
				self = sklearn.cluster.self.InvokeMethod("HDBSCAN", args, pyDict);
			}

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public NDarray probabilities_ => ToCsharp<NDarray>(self.GetAttr("probabilities_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public NDarray centroids_ => ToCsharp<NDarray>(self.GetAttr("centroids_"));

			public NDarray medoids_ => ToCsharp<NDarray>(self.GetAttr("medoids_"));

			public NDarray dbscan_clustering(float cut_distance, int min_cluster_size = 5)
			{
				PyTuple args = ToTuple(new object[] {cut_distance});
				PyDict pyDict = new PyDict();
				pyDict["min_cluster_size"] = ToPython(min_cluster_size);
				PyObject result = self.InvokeMethod("dbscan_clustering", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public HDBSCAN fit(NDarray X, PyObject y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_predict(NDarray X, PyObject y = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				pyDict["y"] = ToPython(y);
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

			public HDBSCAN set_params(PyDict? @params = null)
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

		public class KMeans : PythonObject
		{
			public KMeans(int n_clusters = 8, string init = "k-means++", string n_init = "auto", int max_iter = 300, float tol = 0.0001f, int verbose = 0, int? random_state = null, bool copy_x = true, string algorithm = "lloyd")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				pyDict["init"] = ToPython(init);
				pyDict["n_init"] = ToPython(n_init);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["tol"] = ToPython(tol);
				pyDict["verbose"] = ToPython(verbose);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["copy_x"] = ToPython(copy_x);
				pyDict["algorithm"] = ToPython(algorithm);
				self = sklearn.cluster.self.InvokeMethod("KMeans", args, pyDict);
			}

			public NDarray cluster_centers_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public float inertia_ => ToCsharp<float>(self.GetAttr("inertia_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public KMeans fit(NDarray X, NDarray? sample_weight = null)
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

			public NDarray fit_predict(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("fit_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public KMeans set_fit_request(string? sample_weight = "$UNCHANGED$")
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

			public KMeans set_output(string? transform = null)
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

			public KMeans set_params(PyDict? @params = null)
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

			public KMeans set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class MeanShift : PythonObject
		{
			public MeanShift(float? bandwidth = null, NDarray? seeds = null, bool bin_seeding = false, int min_bin_freq = 1, bool cluster_all = true, int? n_jobs = null, int max_iter = 300)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (bandwidth != null)
				{
					pyDict["bandwidth"] = ToPython(bandwidth);
				}
				if (seeds != null)
				{
					pyDict["seeds"] = ToPython(seeds);
				}
				pyDict["bin_seeding"] = ToPython(bin_seeding);
				pyDict["min_bin_freq"] = ToPython(min_bin_freq);
				pyDict["cluster_all"] = ToPython(cluster_all);
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["max_iter"] = ToPython(max_iter);
				self = sklearn.cluster.self.InvokeMethod("MeanShift", args, pyDict);
			}

			public NDarray cluster_centers_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public MeanShift fit(NDarray X)
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

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public MeanShift set_params(PyDict? @params = null)
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

		public class MiniBatchKMeans : PythonObject
		{
			public MiniBatchKMeans(int n_clusters = 8, string init = "k-means++", int max_iter = 100, int batch_size = 1024, int verbose = 0, bool compute_labels = true, int? random_state = null, float tol = 0.0f, int max_no_improvement = 10, int? init_size = null, string n_init = "auto", float reassignment_ratio = 0.01f)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				pyDict["init"] = ToPython(init);
				pyDict["max_iter"] = ToPython(max_iter);
				pyDict["batch_size"] = ToPython(batch_size);
				pyDict["verbose"] = ToPython(verbose);
				pyDict["compute_labels"] = ToPython(compute_labels);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["tol"] = ToPython(tol);
				pyDict["max_no_improvement"] = ToPython(max_no_improvement);
				if (init_size != null)
				{
					pyDict["init_size"] = ToPython(init_size);
				}
				pyDict["n_init"] = ToPython(n_init);
				pyDict["reassignment_ratio"] = ToPython(reassignment_ratio);
				self = sklearn.cluster.self.InvokeMethod("MiniBatchKMeans", args, pyDict);
			}

			public NDarray cluster_centers_ => ToCsharp<NDarray>(self.GetAttr("cluster_centers_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public float inertia_ => ToCsharp<float>(self.GetAttr("inertia_"));

			public int n_iter_ => ToCsharp<int>(self.GetAttr("n_iter_"));

			public int n_steps_ => ToCsharp<int>(self.GetAttr("n_steps_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public MiniBatchKMeans fit(NDarray X, NDarray? sample_weight = null)
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

			public NDarray fit_predict(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("fit_predict", args, pyDict);
				return ToCsharp<NDarray>(result);
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

			public MiniBatchKMeans partial_fit(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("partial_fit", args, pyDict);
				return this;
			}

			public NDarray predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("predict", args, pyDict);
				return ToCsharp<NDarray>(result);
			}

			public float score(NDarray X, NDarray? sample_weight = null)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				PyObject result = self.InvokeMethod("score", args, pyDict);
				return ToCsharp<float>(result);
			}

			public MiniBatchKMeans set_fit_request(string? sample_weight = "$UNCHANGED$")
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

			public MiniBatchKMeans set_output(string? transform = null)
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

			public MiniBatchKMeans set_params(PyDict? @params = null)
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

			public MiniBatchKMeans set_partial_fit_request(string? sample_weight = "$UNCHANGED$")
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				if (sample_weight != null)
				{
					pyDict["sample_weight"] = ToPython(sample_weight);
				}
				self.InvokeMethod("set_partial_fit_request", args, pyDict);
				return this;
			}

			public MiniBatchKMeans set_score_request(string? sample_weight = "$UNCHANGED$")
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

		public class OPTICS : PythonObject
		{
			public OPTICS(int min_samples = 5, float max_eps = float.PositiveInfinity, string metric = "minkowski", float p = 2, PyObject metric_params = null, string cluster_method = "xi", float? eps = null, float xi = 0.05f, bool predecessor_correction = true, int? min_cluster_size = null, string algorithm = "auto", int leaf_size = 30, int? memory = null, int? n_jobs = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["min_samples"] = ToPython(min_samples);
				pyDict["max_eps"] = ToPython(max_eps);
				pyDict["metric"] = ToPython(metric);
				pyDict["p"] = ToPython(p);
				pyDict["metric_params"] = ToPython(metric_params);
				pyDict["cluster_method"] = ToPython(cluster_method);
				if (eps != null)
				{
					pyDict["eps"] = ToPython(eps);
				}
				pyDict["xi"] = ToPython(xi);
				pyDict["predecessor_correction"] = ToPython(predecessor_correction);
				if (min_cluster_size != null)
				{
					pyDict["min_cluster_size"] = ToPython(min_cluster_size);
				}
				pyDict["algorithm"] = ToPython(algorithm);
				pyDict["leaf_size"] = ToPython(leaf_size);
				if (memory != null)
				{
					pyDict["memory"] = ToPython(memory);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				self = sklearn.cluster.self.InvokeMethod("OPTICS", args, pyDict);
			}

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public NDarray reachability_ => ToCsharp<NDarray>(self.GetAttr("reachability_"));

			public NDarray ordering_ => ToCsharp<NDarray>(self.GetAttr("ordering_"));

			public NDarray core_distances_ => ToCsharp<NDarray>(self.GetAttr("core_distances_"));

			public NDarray predecessor_ => ToCsharp<NDarray>(self.GetAttr("predecessor_"));

			public NDarray cluster_hierarchy_ => ToCsharp<NDarray>(self.GetAttr("cluster_hierarchy_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public OPTICS fit(NDarray X)
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

			public OPTICS set_params(PyDict? @params = null)
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

		public class SpectralBiclustering : PythonObject
		{
			public SpectralBiclustering(int n_clusters = 3, string method = "bistochastic", int n_components = 6, int n_best = 3, string svd_method = "randomized", int? n_svd_vecs = null, bool mini_batch = false, string init = "k-means++", int n_init = 10, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				pyDict["method"] = ToPython(method);
				pyDict["n_components"] = ToPython(n_components);
				pyDict["n_best"] = ToPython(n_best);
				pyDict["svd_method"] = ToPython(svd_method);
				if (n_svd_vecs != null)
				{
					pyDict["n_svd_vecs"] = ToPython(n_svd_vecs);
				}
				pyDict["mini_batch"] = ToPython(mini_batch);
				pyDict["init"] = ToPython(init);
				pyDict["n_init"] = ToPython(n_init);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.cluster.self.InvokeMethod("SpectralBiclustering", args, pyDict);
			}

			public NDarray rows_ => ToCsharp<NDarray>(self.GetAttr("rows_"));

			public NDarray columns_ => ToCsharp<NDarray>(self.GetAttr("columns_"));

			public NDarray row_labels_ => ToCsharp<NDarray>(self.GetAttr("row_labels_"));

			public NDarray column_labels_ => ToCsharp<NDarray>(self.GetAttr("column_labels_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public SpectralBiclustering fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray get_indices(int i)
			{
				PyTuple args = ToTuple(new object[] {i});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_indices", args, pyDict);
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

			public SpectralBiclustering set_params(PyDict? @params = null)
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

		public class SpectralClustering : PythonObject
		{
			public SpectralClustering(int n_clusters = 8, string? eigen_solver = null, int? n_components = null, int? random_state = null, int n_init = 10, float gamma = 1.0f, string affinity = "rbf", int n_neighbors = 10, string eigen_tol = "auto", string assign_labels = "kmeans", float degree = 3, float coef0 = 1, string? kernel_params = null, int? n_jobs = null, bool verbose = false)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				if (eigen_solver != null)
				{
					pyDict["eigen_solver"] = ToPython(eigen_solver);
				}
				if (n_components != null)
				{
					pyDict["n_components"] = ToPython(n_components);
				}
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				pyDict["n_init"] = ToPython(n_init);
				pyDict["gamma"] = ToPython(gamma);
				pyDict["affinity"] = ToPython(affinity);
				pyDict["n_neighbors"] = ToPython(n_neighbors);
				pyDict["eigen_tol"] = ToPython(eigen_tol);
				pyDict["assign_labels"] = ToPython(assign_labels);
				pyDict["degree"] = ToPython(degree);
				pyDict["coef0"] = ToPython(coef0);
				if (kernel_params != null)
				{
					pyDict["kernel_params"] = ToPython(kernel_params);
				}
				if (n_jobs != null)
				{
					pyDict["n_jobs"] = ToPython(n_jobs);
				}
				pyDict["verbose"] = ToPython(verbose);
				self = sklearn.cluster.self.InvokeMethod("SpectralClustering", args, pyDict);
			}

			public NDarray affinity_matrix_ => ToCsharp<NDarray>(self.GetAttr("affinity_matrix_"));

			public NDarray labels_ => ToCsharp<NDarray>(self.GetAttr("labels_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public SpectralClustering fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray fit_predict(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
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

			public SpectralClustering set_params(PyDict? @params = null)
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

		public class SpectralCoclustering : PythonObject
		{
			public SpectralCoclustering(int n_clusters = 3, string svd_method = "randomized", int? n_svd_vecs = null, bool mini_batch = false, string init = "k-means++", int n_init = 10, int? random_state = null)
			{
				PyTuple args = new PyTuple();
				PyDict pyDict = new PyDict();
				pyDict["n_clusters"] = ToPython(n_clusters);
				pyDict["svd_method"] = ToPython(svd_method);
				if (n_svd_vecs != null)
				{
					pyDict["n_svd_vecs"] = ToPython(n_svd_vecs);
				}
				pyDict["mini_batch"] = ToPython(mini_batch);
				pyDict["init"] = ToPython(init);
				pyDict["n_init"] = ToPython(n_init);
				if (random_state != null)
				{
					pyDict["random_state"] = ToPython(random_state);
				}
				self = sklearn.cluster.self.InvokeMethod("SpectralCoclustering", args, pyDict);
			}

			public NDarray rows_ => ToCsharp<NDarray>(self.GetAttr("rows_"));

			public NDarray columns_ => ToCsharp<NDarray>(self.GetAttr("columns_"));

			public NDarray row_labels_ => ToCsharp<NDarray>(self.GetAttr("row_labels_"));

			public NDarray column_labels_ => ToCsharp<NDarray>(self.GetAttr("column_labels_"));

			public int n_features_in_ => ToCsharp<int>(self.GetAttr("n_features_in_"));

			public NDarray feature_names_in_ => ToCsharp<NDarray>(self.GetAttr("feature_names_in_"));

			public SpectralCoclustering fit(NDarray X)
			{
				PyTuple args = ToTuple(new object[] {X});
				PyDict pyDict = new PyDict();
				self.InvokeMethod("fit", args, pyDict);
				return this;
			}

			public NDarray get_indices(int i)
			{
				PyTuple args = ToTuple(new object[] {i});
				PyDict pyDict = new PyDict();
				PyObject result = self.InvokeMethod("get_indices", args, pyDict);
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

			public SpectralCoclustering set_params(PyDict? @params = null)
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

	}
}
