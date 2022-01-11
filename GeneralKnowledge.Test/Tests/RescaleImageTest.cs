using System;
using System.Drawing;
using FreeImageAPI;
using GeneralKnowledge.Test.App.Tests;

namespace GeneralKnowledge.Test.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
             var thumbnail = new Size(100, 80);
             var preview = new Size(1200, 1600);
             const string path = @"Resources\nature.jpg";
            ReScale(path,thumbnail, @"Resources\thumbnail.jpg");
            ReScale(path, preview, @"Resources\preview.jpg");
        }

        private static void ReScale(string path, Size size, string outputPath)
        {
            try
            {
                using var original = FreeImageBitmap.FromFile(path);
               var resized = new FreeImageBitmap(original, size.Width, size.Height);

                //for testing purpose i am storing the file in GeneralKnowledge.Test\bin\Debug\netcoreapp3.1\Resources
                resized.Save(outputPath, FREE_IMAGE_FORMAT.FIF_JPEG,
                    FREE_IMAGE_SAVE_FLAGS.JPEG_QUALITYGOOD |
                    FREE_IMAGE_SAVE_FLAGS.JPEG_BASELINE);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
