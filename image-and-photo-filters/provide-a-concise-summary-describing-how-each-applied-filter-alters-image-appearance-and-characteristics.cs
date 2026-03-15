using System;

namespace AsposeImagingFilterSummary
{
    class Program
    {
        static void Main()
        {
            // Median filter: reduces noise by replacing each pixel with the median value
            // of its neighboring pixels within the specified kernel size.
            Console.WriteLine("Median Filter: Smooths image while preserving edges by using the median of surrounding pixels.");

            // Bilateral smoothing filter: smooths colors while preserving edges,
            // considering both spatial proximity and color similarity.
            Console.WriteLine("Bilateral Smoothing Filter: Reduces noise while keeping edges sharp by weighting pixels based on distance and color difference.");

            // Gaussian blur filter: applies a Gaussian function to blur the image,
            // creating a soft, out-of-focus effect.
            Console.WriteLine("Gaussian Blur Filter: Produces a uniform blur using a Gaussian kernel, softening details and reducing high-frequency noise.");

            // Gauss-Wiener filter: combines Gaussian blur with Wiener deconvolution,
            // aiming to reduce noise while preserving details.
            Console.WriteLine("Gauss-Wiener Filter: Denoises image with adaptive smoothing, balancing blur and detail preservation.");

            // Motion Wiener filter: reduces motion blur and noise by applying a Wiener filter
            // oriented along a specified motion direction.
            Console.WriteLine("Motion Wiener Filter: Mitigates motion blur and noise using directional Wiener filtering based on length and angle.");

            // Sharpen filter: enhances edges by emphasizing differences between neighboring pixels,
            // making the image appear clearer and more detailed.
            Console.WriteLine("Sharpen Filter: Increases contrast of edges to make details stand out, counteracting blur.");
        }
    }
}