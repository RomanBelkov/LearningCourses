import kmeans
import numpy as np
from math import sqrt
import matplotlib.pyplot as plt


def barycenter(w):
    center = np.zeros(w[0].size)
    count = 0
    for i, x in enumerate(w):
        for j in xrange(0, x.size):
            a = x[j].astype(int)
            center[j] += a
        count += 1
    for y in range(0, center.size):
        try:
            center[y] /= count
        except Exception:
            pass
    return center


# between samples
def bgss(w, centers, ns, degree=2):
    g = barycenter(w)
    result = 0
    for i, center in enumerate(centers):
        x = pow(np.linalg.norm(g - center), degree)
        result += ns[i] * x
    return result


# within samples
def wgss(w, clusters, center, cluster_index, degree=2):
    res = 0
    for i, x in enumerate(w):
        if cluster_index == clusters[i]:
            t = pow(np.linalg.norm(x - center), degree)
            res += t
    return res


def read_external_data(input_file):
    f = open(input_file, 'r')
    s = f.read().split("\r\n")
    if s[-1] == '':
        s = s[:-1]
    result = np.empty([len(s), len(s[0].split(' ')) - 1])
    correct = [0] * len(s)
    for i, values in enumerate(s):
        x = values.split(' ')
        result[i] = np.array((float(x[1]), float(x[2])))
        correct[i] = int(x[0])

    return correct, result


if __name__ == "__main__":
    input_image = "policemen.jpg"
    image, w = kmeans.image_to_matrices(input_image)
    min_k, max_k = 2, 20

    # init indices
    init_index = (max_k - min_k + 1)
    DavBoul = [0] * init_index
    CalHar = [0] * init_index
    Rand = [0] * init_index
    FowMal = [0] * init_index

    for k in range(min_k, max_k + 1):
        try:
            clusters = kmeans.kmeans(w, k)
            centers = kmeans.cluster_centroids(w, clusters, k)

            # prelim counts
            ns = [0] * k
            for i in clusters:
                ns[i] += 1
            tb = False
            for i in ns:
                if i == 0:
                    tb = True
                    break
            if tb:
                continue

            # CalHar
            wgssSum = 0
            bgssSum = bgss(w, centers, ns)
            for i in range(k):
                wgssSum += wgss(w, clusters, centers[i], i)
            CalHar[k - min_k] = bgssSum * (len(clusters) - k) / (wgssSum * (k - 1))

            # DavBoul
            meanDists = [0] * k
            for i in range(k):
                meanDists[i] = wgss(w, clusters, centers[i], i, 1) / ns[i]
            for i in range(k):
                t = 0
                for j in range(k):
                    if i != j:
                        t = max(t, (meanDists[i] + meanDists[j]) / np.linalg.norm(centers[i] - centers[j]))
                DavBoul[k - min_k] += t / k

            correct_partitioning, external_data = read_external_data("task_2_data_7.txt")
            clusters = kmeans.kmeans(external_data, k)

            yy = 0
            yn = 0
            ny = 0
            nn = 0
            for i in xrange(len(correct_partitioning)):
                for j in xrange(i + 1, len(correct_partitioning)):
                    if correct_partitioning[i] == correct_partitioning[j]:
                        if clusters[i] == clusters[j]:
                            yy += 1
                        else:
                            yn += 1
                    else:
                        if clusters[i] == clusters[j]:
                            ny += 1
                        else:
                            nn += 1

            # Rand
            Rand[k - min_k] = (yy + nn) / len(clusters)

            # FowMal
            FowMal[k - min_k] = yy / (sqrt((yy + yn) * (yy + ny)))

        except Exception:
            pass

    print("From " + str(min_k) + " to " + str(max_k))
    print("DavBoul: " + str(DavBoul))
    print("CalHar: " + str(CalHar))
    print("Rand: " + str(Rand))
    print("FowMal: " + str(FowMal))

    x_range = range(min_k, max_k + 1)

    plt.plot(x_range, DavBoul, 'ro')
    plt.ylabel('DavBoul')
    plt.show()

    plt.plot(x_range, CalHar, 'ro')
    plt.ylabel('CalHar')
    plt.show()

    plt.plot(x_range, Rand, 'ro')
    plt.ylabel('Rand')
    plt.show()

    plt.plot(x_range, FowMal, 'ro')
    plt.ylabel('FowMal')
    plt.show()

    delta_CalHar = [(CalHar[k + 1] - CalHar[k]) - (CalHar[k] - CalHar[k - 1]) for k in xrange(1, max_k - min_k)]

    for arr in [DavBoul, delta_CalHar]:
        min = (0, float("inf"))
        for i, x in enumerate(arr):
            if x < min[1]:
                min = i, x
        print("Best num: " + str(min[0] + 1))
        # kmeans.getImg(input_file, m[0] + min_k)
        #image, w = kmeans.image_to_matrices(input_image)
        #kmeans.save_image(centers, clusters, w.shape[0], image.shape, "policemen-" + str(min[0] + 1))
