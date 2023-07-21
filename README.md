Introduction:

The solution to this problem simply makes use of a KDTree to do efficient looks ups and comparisons. 

To run the solution you can simply open it in visual studio and hit execute / start 

Then the solution will run

The program will then read the binary file, then start a stop watch to track the time taken for the execution of the program
once the program is complete it will log all the relevant positions closest to reach position

Problem-solving approach:

Efficient Lookup: The main goal of the problem is to find the nearest vehicle positions to a set of given coordinates. To achieve this efficiently, the solution utilizes a KDTree data structure. The KDTree enables spatial indexing and reduces the number of distance calculations required, resulting in faster lookup times compared to a brute-force approach.

KDTree Implementation: The KDTree is a hierarchical tree structure that divides space into child nodes. Each node represents a region and have two child nodes. The tree is built by recursively subdividing nodes based on the number of positions they contain. This approach allows for efficient storage and retrieval of vehicle positions based on their coordinates.

Design decisions:

KDTreeNode Structure: The KDTreeNode class is designed to represent a node in the KDTree. It contains properties such as Parent, Children, VehiclePositions. These properties store information about the node's location, dimensions, parent-child relationships, and the vehicle positions associated with the node.

Nearest Neighbor Search: To find the nearest vehicle positions, a recursive algorithm is used to traverse the KDTree. Starting from the root node, the algorithm checks each node's distance to the target coordinates and narrows down the search to the most promising child nodes. This process continues until the algorithm reaches leaf nodes or nodes with no closer candidates.

Assumptions made:

Binary Data File Structure: The solution assumes that the binary data file follows the specified structure provided in the assignment. It assumes that the binary file contains vehicle positions stored in a specific format: VehicleId (Int32), VehicleRegistration (Null Terminated ASCII String), Latitude (Float), Longitude (Float), and RecordedTimeUTC (UInt64).

File Size and Memory: The solution assumes that the file size and available memory are manageable within the system's resources. It loads the entire file into memory for processing. If the file size is extremely large or the memory is limited, alternative strategies like chunk-based processing or streaming should be considered.

Distance Calculation: The solution assumes that the distance calculation between coordinates uses the Euclidean distance formula. The formula calculates the straight-line distance between two points in a two-dimensional space. If a different distance metric is required, the formula can be modified accordingly.

Overall, the solution utilizes a KDTree data structure and a nearest neighbor search algorithm to efficiently find the nearest vehicle positions. It makes design decisions to represent the KDTree nodes and leverages assumptions about the binary file structure and available resources.