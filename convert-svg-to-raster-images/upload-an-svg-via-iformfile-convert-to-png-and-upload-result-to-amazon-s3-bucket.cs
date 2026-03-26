using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG and rasterize to PNG
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Set up rasterization options (default options are sufficient for most cases)
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Configure PNG save options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save rasterized PNG to the output path
            svgImage.Save(outputPath, pngOptions);
        }

        // Upload the generated PNG to Amazon S3
        const string bucketName = "my-s3-bucket";
        const string objectKey = "output.png";

        // Create an S3 client (uses default credentials and region)
        using (var s3Client = new AmazonS3Client(RegionEndpoint.USEast1))
        using (var fileStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = fileStream,
                ContentType = "image/png"
            };

            s3Client.PutObjectAsync(putRequest).GetAwaiter().GetResult();
        }

        Console.WriteLine("SVG converted to PNG and uploaded to S3 successfully.");
    }
}