using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using ImageClassification.ImageDataStructures;
using static ImageClassification.ModelScorer.ConsoleHelpers;
using static ImageClassification.ModelScorer.ModelHelpers;
using System.IO;

namespace ImageClassification.ModelScorer
{
    public class pred_model
    {
        private readonly string dataLocation;
        private readonly string imagesFolder;
        private readonly string modelLocation;
        private readonly string labelsLocation;
        private readonly string img_name;
        private readonly MLContext mlContext;
        private static string ImageReal = nameof(ImageReal);

        public pred_model(string dataLocation, string imagesFolder, string modelLocation, string labelsLocation, string img_name)
        {
            this.dataLocation = dataLocation;
            this.imagesFolder = imagesFolder;
            this.modelLocation = modelLocation;
            this.labelsLocation = labelsLocation;
            this.img_name = img_name;
            mlContext = new MLContext();
        }
        public ImageNetDataProbability Predict()
        {
            Write_to_file(dataLocation, img_name);
            try
            {
                var modelScorer = new TFModelScorer(dataLocation, imagesFolder, modelLocation, labelsLocation);
                var res = modelScorer.Score().Single();
                return res;
            }
            catch (Exception ex)
            {
                ConsoleHelpers.ConsoleWriteException(ex.ToString());
                return null;
            }
        }
        static void Write_to_file(string tagsTsv, string img_name)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(tagsTsv, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(img_name);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

