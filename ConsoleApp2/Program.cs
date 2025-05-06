
﻿using System.Collections;

// Main program to test the Bloom Filter
class Program {
    static void Main () {
        // Create a BloomFilter for strings with size 1000 and using 4 hash functions
        BloomFilter<string> filter = new BloomFilter<string>( 1000, 4 );

        // Add elements to the Bloom Filter
        filter.Add( "apple" );
        filter.Add( "banana" );

        // Check for element presence
        Console.WriteLine( filter.MightContain( "apple" ) );   // Expected: true
        Console.WriteLine( filter.MightContain( "grapes" ) );  // Might be false (most likely)
    }
}

// Generic Bloom Filter class
class BloomFilter<T> {
    private BitArray bloomArray; // Bit array that stores the filter data
    private int hashCount;       // Number of hash functions used

    // Constructor: Initializes the Bloom Filter with given size and number of hash functions
    public BloomFilter ( int bloomArraySize, int hashCount ) {
        this.bloomArray = new BitArray( bloomArraySize ); // All bits initialized to false
        this.hashCount = hashCount;
    }

    // Adds an element to the Bloom Filter
    public void Add ( T element ) {
        // Get positions to set using the hash functions
        int[] hash = GetHashes( element );

        // Set each bit at the calculated positions to true
        foreach (int position in hash) {
            bloomArray[position] = true;
        }
    }

    // Checks if an element *might* be in the set
    public bool MightContain ( T element ) {
        // Get hash positions to check
        int[] hash = GetHashes( element );

        // If any one of the positions is false, the element is definitely not present
        foreach (int position in hash) {
            if (!bloomArray[position])
                return false; // Definitely not in the set
        }

        // If all positions are true, it might be in the set
        return true;
    }

    // Generates multiple hash values for the given element
    private int[] GetHashes ( T element ) {
        int[] result = new int[hashCount]; // Array to store hash positions

        string baseString = element!.ToString()!; // Convert the element to a string

        // Create multiple hash values using variations of the input
        for (int i = 0; i < hashCount; i++) {
            // Add a salt value `i` to make different variations
            string combined = baseString + i;

            // Use built-in GetHashCode to generate a hash, then take absolute value
            int hash = Math.Abs( combined.GetHashCode() );

            // Use modulo operation to map the hash to a valid bit array index
            int index = hash % bloomArray.Length;

            result[i] = index; // Store the index
        }

        return result; // Return all calculated positions
    }
}

