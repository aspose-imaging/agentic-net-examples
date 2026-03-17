using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Load the TGA image
        using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
        {
            // Ensure image data is cached for better performance
            if (!tgaImage.IsCached) tgaImage.CacheData();

            // Update metadata properties
            tgaImage.DateTimeStamp = DateTime.Now;
            tgaImage.AuthorName = "Jane Doe";
            tgaImage.AuthorComments = "Sample comment";
            tgaImage.ImageId = "Img001";
            tgaImage.JobNameOrId = "Job123";
            tgaImage.JobTime = TimeSpan.FromHours(5);
            tgaImage.TransparentColor = Color.FromArgb(0, 0, 0, 0);
            tgaImage.SoftwareId = "MySoftware";
            tgaImage.SoftwareVersion = "1.0";
            tgaImage.SoftwareVersionLetter = 'b';
            tgaImage.SoftwareVersionNumber = 1;
            tgaImage.XOrigin = 0;
            tgaImage.YOrigin = 0;

            // Crop the central region of the image
            int cropWidth = tgaImage.Width / 2;
            int cropHeight = tgaImage.Height / 2;
            int cropX = (tgaImage.Width - cropWidth) / 2;
            int cropY = (tgaImage.Height - cropHeight) / 2;
            tgaImage.Crop(new Rectangle(cropX, cropY, cropWidth, cropHeight));

            // Resize the image to double its dimensions using nearest-neighbour resampling
            tgaImage.Resize(tgaImage.Width * 2, tgaImage.Height * 2, ResizeType.NearestNeighbourResample);

            // Rotate the image 45 degrees, keep canvas size, fill background with gray
            tgaImage.Rotate(45f, true, Color.Gray);

            // Save the modified TGA image
            tgaImage.Save(outputPath);
        }
    }
}