# Bloom Filter

A **Bloom Filter** is a data structure used to efficiently test whether an element is a member of a set.  
It is mainly a **space-optimized** version of hashing where **false positives** are possible.

The key idea is:
- Do **not store the actual key**.
- Instead, store only **hash values**.
- It uses **less than 10 bits per key** to maintain around **1% false positive rate**.
- It does **not depend** on the size of the individual keys.

---

## What is a Bloom Filter?

A Bloom filter is a **space-efficient probabilistic data structure** that tests membership of an element in a set.

**Example Use Case:**  
Checking the **availability of a username**. This is a set membership problem where the set is the list of all registered usernames.

**Trade-off:**  
- It is **probabilistic**, not deterministic.
- You may get **false positives**.
    - For example, the filter might say: “Username is taken” when it's **actually not**.
- But you will **never get false negatives**.
    - If it says: “Username is not taken,” you can trust it.

---

## Interesting Properties of Bloom Filters

- **Space Efficiency:**  
  A Bloom filter of a **fixed size** can represent a set with an **arbitrarily large number of elements**.

- **Always Accepts Additions:**  
  Adding an element **never fails**.  
  However, the **false positive rate** increases as more elements are added.  
  Eventually, all bits may become `1`, causing **every query** to return **positive**.

- **No False Negatives:**  
  A Bloom filter **never incorrectly reports absence**.  
  If it says an element **is not in the set**, that is guaranteed to be true.

- **No Deletion Support:**  
  Deletion is **not safe** in a basic Bloom filter.  
  If you try to clear bits for an element, you might **accidentally remove bits** that were also set for **other elements**.

  **Example:**  
  If we delete "geeks" by clearing bits at indices 1, 4, and 7, we may unintentionally delete "nerd" if both shared index 4. After clearing, the filter would wrongly report that "nerd" is not present.
