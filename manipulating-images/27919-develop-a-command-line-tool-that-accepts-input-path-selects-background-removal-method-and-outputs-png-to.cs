using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Choose background removal method: "GraphCut", "KMeans", or "Manual"
                string methodChoice = "GraphCut";

                // Prepare export options for PNG with transparency
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking options based on the selected method
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    ExportOptions = exportOptions,
                    Decompose = false // default, may be overridden per method
                };

                if (methodChoice == "GraphCut")
                {
                    maskingOptions.Method = SegmentationMethod.GraphCut;
                    maskingOptions.Args = new AutoMaskingArgs();
                    maskingOptions.BackgroundReplacementColor = Color.Transparent;
                }
                else if (methodChoice == "KMeans")
                {
                    maskingOptions.Method = SegmentationMethod.KMeans;
                    maskingOptions.Decompose = true;
                    AutoMaskingArgs argsK = new AutoMaskingArgs
                    {
                        NumberOfObjects = 2,
                        MaxIterationNumber = 50,
                        Precision = 1
                    };
                    maskingOptions.Args = argsK;
                    maskingOptions.BackgroundReplacementColor = Color.Orange;
                }
                else if (methodChoice == "Manual")
                {
                    maskingOptions.Method = SegmentationMethod.Manual;
                    maskingOptions.Decompose = false;

                    // Define a simple manual mask (ellipse + rectangle)
                    GraphicsPath manualMask = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new EllipseShape(new Rectangle(50, 50, 100, 100)));
                    figure.AddShape(new RectangleShape(new Rectangle(200, 200, 150, 100)));
                    manualMask.AddFigure(figure);

                    ManualMaskingArgs manualArgs = new ManualMaskingArgs
                    {
                        Mask = manualMask
                    };
                    maskingOptions.Args = manualArgs;
                    maskingOptions.BackgroundReplacementColor = Color.Orange;
                }
                else
                {
                    Console.Error.WriteLine("Unsupported method choice.");
                    return;
                }

                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                {
                    // Get the foreground image (index 1)
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        foreground.Save(outputPath, exportOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When an online retailer needs to automatically strip the background from thousands of product JPEG photos and save them as transparent PNGs for catalog listings, they can run this C# command‑line tool with the GraphCut method.
 * 2. When a marketing team wants to quickly prepare social‑media graphics by removing the background of user‑submitted images and exporting them as PNGs with alpha transparency, they can invoke the tool from a script and choose the KMeans segmentation for fast results.
 * 3. When a document‑digitization workflow must isolate scanned signatures from their white paper background and output them as transparent PNGs for secure electronic forms, developers can call the tool with the Manual method to fine‑tune the mask.
 * 4. When a game developer needs to batch convert concept‑art JPEGs into PNG sprites with removed backgrounds for use in Unity, they can integrate the Aspose.Imaging C# utility into their build pipeline and select the desired segmentation algorithm.
 * 5. When an AR/VR content creator wants to extract foreground objects from photography and generate PNG assets with transparent backgrounds for real‑time rendering, they can run the command‑line application on a folder of images and output the results to a target directory.
 */