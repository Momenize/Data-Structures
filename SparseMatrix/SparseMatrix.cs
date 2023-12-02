namespace SparseMatrix
{
    internal class SparseMatrix
    {
        public Head[] head;
        public SparseMatrix(int[,] a)  
        {
            
            head = new Head[a.GetLength(1)];
            for(int i = 0; i < a.GetLength(1) - 1; i++)
            {
                head[i].next = head[i + 1];
            }
            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] != 0)
                    {
                        var node = new Node(a[i, j]);
                    }
                }
            }
        }   
    }
}
