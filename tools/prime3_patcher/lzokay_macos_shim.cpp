#include "lzokay.hpp"

#include <cstddef>
#include <cstdint>
#include <cstring>

namespace
{

bool valid_arguments(
    const std::uint8_t* source,
    int source_length,
    std::uint8_t* destination,
    int destination_length,
    int* final_length)
{
    return source != nullptr
        && source_length >= 0
        && destination != nullptr
        && destination_length >= 0
        && final_length != nullptr;
}

}  // namespace

extern "C"
{

__attribute__((visibility("default")))
void decompress(
    const std::uint8_t* source,
    int source_length,
    std::uint8_t* destination,
    int destination_length,
    int* final_length)
{
    if (!valid_arguments(
            source,
            source_length,
            destination,
            destination_length,
            final_length))
    {
        if (final_length != nullptr)
        {
            *final_length = 0;
        }
        return;
    }

    std::size_t output_length =
        static_cast<std::size_t>(destination_length);

    const lzokay::EResult result = lzokay::decompress(
        source,
        static_cast<std::size_t>(source_length),
        destination,
        static_cast<std::size_t>(destination_length),
        output_length);

    *final_length = static_cast<int>(output_length);

    if (static_cast<int>(result) < 0)
    {
        *final_length = 0;
    }
}

__attribute__((visibility("default")))
void compress_without_dict(
    const std::uint8_t* source,
    int source_length,
    std::uint8_t* destination,
    int destination_length,
    int* final_length)
{
    if (!valid_arguments(
            source,
            source_length,
            destination,
            destination_length,
            final_length))
    {
        if (final_length != nullptr)
        {
            *final_length = 0;
        }
        return;
    }

    std::size_t output_length =
        static_cast<std::size_t>(destination_length);

    const lzokay::EResult result = lzokay::compress(
        source,
        static_cast<std::size_t>(source_length),
        destination,
        static_cast<std::size_t>(destination_length),
        output_length);

    if (static_cast<int>(result) >= 0)
    {
        *final_length = static_cast<int>(output_length);
        return;
    }

    // MP3Randomizer treats output that is not smaller than the input as an
    // uncompressed block. Fall back to copying the original bytes.
    if (destination_length >= source_length)
    {
        std::memcpy(
            destination,
            source,
            static_cast<std::size_t>(source_length));
        *final_length = source_length;
    }
    else
    {
        *final_length = 0;
    }
}

}  // extern "C"
