using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 전치행렬
{
	class Program
	{
		static void Main(string[] args) {
			int[,] mat1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };		// 2x3 배열
			int[,] mat2 = new int[mat1.GetLength(1), mat1.GetLength(0)];	// 3x2 배열 GetLength(0) 행의 갯수, GetLength(1) 열의 갯수
			printMatrix(mat1);
			mat2 = transpose(mat1);
			printMatrix(mat2);
		}
		public static int[,] transpose(int[,] m1) {
			int[,] result = new int[m1.GetLength(1), m1.GetLength(0)];
			for(int i = 0; i < m1.GetLength(1); i++) {
				for (int j = 0; j < m1.GetLength(0); j++) {
					result[i,j] = m1[j,i];
				}
			}
			return result;
		}
		public static void printMatrix(int[,] mat) { 
			for(int i  = 0; i < mat.GetLength(0); i++) { 
				for(int j = 0; j < mat.GetLength(1); j++) {
					Console.Write(mat[i,j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}
