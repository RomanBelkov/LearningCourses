import scipy.spatial
from PIL import Image
import numpy as np


def run_cost(centroids, clusters, X):
    return sum(np.linalg.norm(X[i] - centroids[clusters[i]]) for i in xrange(len(clusters)))


def cluster_centroids(data, clusters, k=None):
    if k is None:
        k = np.max(clusters) + 1
    result = np.empty(shape=(k,) + data.shape[1:])
    for i in range(k):
        np.mean(data[clusters == i], axis=0, out=result[i])
    return result


def kmeans(data, k=None, centroids=None, steps=100):
    if centroids is not None and k is not None:
        assert (k == len(centroids))
    elif centroids is not None:
        k = len(centroids)
    elif k is not None:
        centroids = data[np.random.choice(np.arange(len(data)), k, False)]
    else:
        raise RuntimeError("Need a value for k or centroids.")

    for _ in range(max(steps, 1)):
        # Squared distances between each point and each centroid.
        sqdists = scipy.spatial.distance.cdist(centroids, data, 'sqeuclidean')

        # Index of the closest centroid to each data point.
        clusters = np.argmin(sqdists, axis=0)

        new_centroids = cluster_centroids(data, clusters, k)

        if np.array_equal(new_centroids, centroids):
            break

        centroids = new_centroids

    return clusters


if __name__ == "__main__":
    input_image = 'grain.jpg'
    output_image = 'grain-out.jpg'

    k = 20
    steps = 100
    runs = 5

    image = np.array(Image.open(input_image))
    X = image.reshape((image.shape[0] * image.shape[1], image.shape[2]))

    cost = float("inf")
    clusters = []
    centroids = []

    for _ in xrange(runs):
        new_clusters = kmeans(X, k, steps=steps)
        new_centroids = cluster_centroids(X, new_clusters, k)

        new_cost = run_cost(new_centroids, new_clusters, X)

        print(cost, new_cost)
        if new_cost < cost:
            clusters = new_clusters
            centroids = new_centroids
            cost = new_cost

    new_X = np.array([centroids[clusters[i]] for i in xrange(X.shape[0])])

    new_image = new_X.reshape(image.shape)
    save_image = Image.fromarray(new_image.astype('uint8'))
    save_image.save(output_image)
