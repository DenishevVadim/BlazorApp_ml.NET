using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImageClassification.ImageDataStructures
{
    public class ImageNetData
    {
        [LoadColumn(0)]
        public string ImagePath;

        public static IEnumerable<ImageNetData> ReadFromCsv(string file, string folder)
        {
            return File.ReadAllLines(file)
             .Select(x => x.Split('\t'))
             .Select(x => new ImageNetData { ImagePath = Path.Combine(folder, x[0])});
        }
    }

    public class ImageNetDataProbability : ImageNetData
    {
        public string PredictedLabel;
        public float Probability { get; set; }
    }
}
