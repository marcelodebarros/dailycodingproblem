using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;
using System.Numerics;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Output:
 * Processing...
Negative: 19996, Positive: 10004
Training the model...
Automatically adding a MinMax normalization transform, use 'norm=Warn' or 'norm=No' to turn this behavior off.
LBFGS multi-threading will attempt to load dataset into memory. In case of out-of-memory issues, add 'numThreads=1' to the trainer arguments and 'cache=-' to the command line arguments to turn off multi-threading.
Beginning optimization
num vars: 154
improvement criterion: Mean Improvement
L1 regularization selected 146 of 154 weights.
Not training a calibrator because it is not needed.
Done!
Confusion Matrix for N = 10000:
Positive-Positive: 94
Positive-Negative: 391
Negative-Positive: 1090
Negative-Negative: 8425
Precision: 7.93918918918919%
Recall: 19.3814432989691%
Accuracy Model: 84.58%
 * 
 */
namespace MLPrimalityTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string trainingData = "training.txt";
			GenerateTrainingData(trainingData);
			PredictionModel<NumberData, NumberPrediction> model = TrainModel(trainingData);
			TestModel(model);
		}

		public static void TestModel(PredictionModel<NumberData, NumberPrediction> model)
		{
			Random rd = new Random();
			int pp = 0;
			int pn = 0;
			int np = 0;
			int nn = 0;
			int randomGuessesRight = 0;
			int modelGetsRight = 0;
			int N = 10000;
			Hashtable seenBefore = new Hashtable();
			for (int i = 0; i < N; )
			{
				BigInteger a = new BigInteger(rd.Next());
				BigInteger b = new BigInteger(rd.Next());

				BigInteger c = a * b + 1;
				if (seenBefore.ContainsKey(c)) continue;
				seenBefore.Add(c, true);

				string trueValue = "";
				string predictedValue = "";
				Predict(model, c, out trueValue, out predictedValue);

				if (trueValue.Equals("Prime") && predictedValue.Equals("Prime")) pp++;
				else if (trueValue.Equals("Prime") && predictedValue.Equals("NotPrime")) pn++;
				else if (trueValue.Equals("NotPrime") && predictedValue.Equals("Prime")) np++;
				else if (trueValue.Equals("NotPrime") && predictedValue.Equals("NotPrime")) nn++;
				i++;

				//Try here
				a = new BigInteger(rd.Next());
				b = new BigInteger(rd.Next());
				c = a * b - 1;
				bool isPrime = IsPrimeMillerRabin(c);
				Predict(model, c, out trueValue, out predictedValue);
				bool randomGuess = rd.Next(0, (int)Math.Log(N)) == 0;

				if ((isPrime && randomGuess) || (!isPrime && !randomGuess)) randomGuessesRight++;
				if ((isPrime && predictedValue.Equals("Prime")) || (!isPrime && predictedValue.Equals("NotPrime"))) modelGetsRight++;
			}
			Console.WriteLine("Confusion Matrix for N = {0}:", N);
			Console.WriteLine("Positive-Positive: {0}", pp);
			Console.WriteLine("Positive-Negative: {0}", pn);
			Console.WriteLine("Negative-Positive: {0}", np);
			Console.WriteLine("Negative-Negative: {0}", nn);

			Console.WriteLine("Precision: {0}%", (100.0 * pp) / (pp + np));
			Console.WriteLine("Recall: {0}%", (100.0 * pp) / (pp + pn));
			Console.WriteLine("Accuracy Random Guesses: {0}%", (100.0 * randomGuessesRight) / N);
			Console.WriteLine("Accuracy Model: {0}%", (100.0 * modelGetsRight) / N);
		}

		public static NumberData CreateNumberDataFromBinary(string bi)
		{
			string[] b = bi.Split(',');

			NumberData nd = new NumberData();
			nd.b0 = (float)Convert.ToInt32(b[0]);
			nd.b1 = (float)Convert.ToInt32(b[1]);
			nd.b2 = (float)Convert.ToInt32(b[2]);
			nd.b3 = (float)Convert.ToInt32(b[3]);
			nd.b4 = (float)Convert.ToInt32(b[4]);
			nd.b5 = (float)Convert.ToInt32(b[5]);
			nd.b6 = (float)Convert.ToInt32(b[6]);
			nd.b7 = (float)Convert.ToInt32(b[7]);
			nd.b8 = (float)Convert.ToInt32(b[8]);
			nd.b9 = (float)Convert.ToInt32(b[9]);
			nd.b10 = (float)Convert.ToInt32(b[10]);
			nd.b11 = (float)Convert.ToInt32(b[11]);
			nd.b12 = (float)Convert.ToInt32(b[12]);
			nd.b13 = (float)Convert.ToInt32(b[13]);
			nd.b14 = (float)Convert.ToInt32(b[14]);
			nd.b15 = (float)Convert.ToInt32(b[15]);
			nd.b16 = (float)Convert.ToInt32(b[16]);
			nd.b17 = (float)Convert.ToInt32(b[17]);
			nd.b18 = (float)Convert.ToInt32(b[18]);
			nd.b19 = (float)Convert.ToInt32(b[19]);
			nd.b20 = (float)Convert.ToInt32(b[20]);
			nd.b21 = (float)Convert.ToInt32(b[21]);
			nd.b22 = (float)Convert.ToInt32(b[22]);
			nd.b23 = (float)Convert.ToInt32(b[23]);
			nd.b24 = (float)Convert.ToInt32(b[24]);
			nd.b25 = (float)Convert.ToInt32(b[25]);
			nd.b26 = (float)Convert.ToInt32(b[26]);
			nd.b27 = (float)Convert.ToInt32(b[27]);
			nd.b28 = (float)Convert.ToInt32(b[28]);
			nd.b29 = (float)Convert.ToInt32(b[29]);
			nd.b30 = (float)Convert.ToInt32(b[30]);
			nd.b31 = (float)Convert.ToInt32(b[31]);
			nd.b32 = (float)Convert.ToInt32(b[32]);
			nd.b33 = (float)Convert.ToInt32(b[33]);
			nd.b34 = (float)Convert.ToInt32(b[34]);
			nd.b35 = (float)Convert.ToInt32(b[35]);
			nd.b36 = (float)Convert.ToInt32(b[36]);
			nd.b37 = (float)Convert.ToInt32(b[37]);
			nd.b38 = (float)Convert.ToInt32(b[38]);
			nd.b39 = (float)Convert.ToInt32(b[39]);
			nd.b40 = (float)Convert.ToInt32(b[40]);
			nd.b41 = (float)Convert.ToInt32(b[41]);
			nd.b42 = (float)Convert.ToInt32(b[42]);
			nd.b43 = (float)Convert.ToInt32(b[43]);
			nd.b44 = (float)Convert.ToInt32(b[44]);
			nd.b45 = (float)Convert.ToInt32(b[45]);
			nd.b46 = (float)Convert.ToInt32(b[46]);
			nd.b47 = (float)Convert.ToInt32(b[47]);
			nd.b48 = (float)Convert.ToInt32(b[48]);
			nd.b49 = (float)Convert.ToInt32(b[49]);
			nd.b50 = (float)Convert.ToInt32(b[50]);
			nd.b51 = (float)Convert.ToInt32(b[51]);
			nd.b52 = (float)Convert.ToInt32(b[52]);
			nd.b53 = (float)Convert.ToInt32(b[53]);
			nd.b54 = (float)Convert.ToInt32(b[54]);
			nd.b55 = (float)Convert.ToInt32(b[55]);
			nd.b56 = (float)Convert.ToInt32(b[56]);
			nd.b57 = (float)Convert.ToInt32(b[57]);
			nd.b58 = (float)Convert.ToInt32(b[58]);
			nd.b59 = (float)Convert.ToInt32(b[59]);
			nd.b60 = (float)Convert.ToInt32(b[60]);
			nd.b61 = (float)Convert.ToInt32(b[61]);
			nd.b62 = (float)Convert.ToInt32(b[62]);
			nd.b63 = (float)Convert.ToInt32(b[63]);
			nd.b64 = (float)Convert.ToInt32(b[64]);
			nd.b65 = (float)Convert.ToInt32(b[65]);
			nd.b66 = (float)Convert.ToInt32(b[66]);
			nd.b67 = (float)Convert.ToInt32(b[67]);
			nd.b68 = (float)Convert.ToInt32(b[68]);
			nd.b69 = (float)Convert.ToInt32(b[69]);
			nd.b70 = (float)Convert.ToInt32(b[70]);
			nd.b71 = (float)Convert.ToInt32(b[71]);
			nd.b72 = (float)Convert.ToInt32(b[72]);
			nd.b73 = (float)Convert.ToInt32(b[73]);
			nd.b74 = (float)Convert.ToInt32(b[74]);
			nd.b75 = (float)Convert.ToInt32(b[75]);

			if (b.Length > 76) nd.Label = b[76];

			return nd;
		}

		public static PredictionModel<NumberData, NumberPrediction> TrainModel(string trainingData)
		{
			Console.WriteLine("Training the model...");
			var pipeline = new LearningPipeline();
			TextLoader training = new TextLoader(trainingData);
			pipeline.Add(training.CreateFrom<NumberData>(separator: ','));
			pipeline.Add(new Dictionarizer("Label"));
			pipeline.Add(new ColumnConcatenator("Features", 
												"b0",
												"b1",
												"b2",
												"b3",
												"b4",
												"b5",
												"b6",
												"b7",
												"b8",
												"b9",
												"b10",
												"b11",
												"b12",
												"b13",
												"b14",
												"b15",
												"b16",
												"b17",
												"b18",
												"b19",
												"b20",
												"b21",
												"b22",
												"b23",
												"b24",
												"b25",
												"b26",
												"b27",
												"b28",
												"b29",
												"b30",
												"b31",
												"b32",
												"b33",
												"b34",
												"b35",
												"b36",
												"b37",
												"b38",
												"b39",
												"b40",
												"b41",
												"b42",
												"b43",
												"b44",
												"b45",
												"b46",
												"b47",
												"b48",
												"b49",
												"b50",
												"b51",
												"b52",
												"b53",
												"b54",
												"b55",
												"b56",
												"b57",
												"b58",
												"b59",
												"b60",
												"b61",
												"b62",
												"b63",
												"b64",
												"b65",
												"b66",
												"b67",
												"b68",
												"b69",
												"b70",
												"b71",
												"b72",
												"b73",
												"b74",
												"b75"));
			pipeline.Add(new LogisticRegressionClassifier());
			pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });
			var model = pipeline.Train<NumberData, NumberPrediction>();
			Console.WriteLine("Done!");

			return model;
		}

		public static void Predict(PredictionModel<NumberData, NumberPrediction> model, 
								   BigInteger n,
								   out string trueValue,
								   out string predictedValue)
		{
			string str = ConvertBigIntegerToBinary(n);

			BigInteger t = new BigInteger(Int32.MaxValue);
			BigInteger v = t * t;
			string val = ConvertBigIntegerToBinary(v);
			while (str.Length < val.Length) str = "0," + str;

			NumberData nd = CreateNumberDataFromBinary(str);
			bool tval = IsPrimeMillerRabin(n);
			NumberPrediction np = model.Predict(nd);

			trueValue = tval ? "Prime" : "NotPrime";
			predictedValue = np.PredictedLabel;

			/*DEBUG
			Console.WriteLine("Number: {0}. Is it Prime?", n);
			Console.WriteLine("True Value: {0}", trueValue);
			Console.WriteLine("Predicted Value: {0}", np.PredictedLabel);
			*/
		}

		public static void GenerateTrainingData(string trainingData)
		{
			int N = 30000;
			FileInfo fi = new FileInfo(trainingData);
			StreamWriter sw = fi.CreateText();

			BigInteger t = new BigInteger(Int32.MaxValue);
			BigInteger v = t * t;
			string val = ConvertBigIntegerToBinary(v);

			Random rd = new Random();
			Hashtable seenBefore = new Hashtable();

			Console.WriteLine("Processing...");
			int count = 0;
			for (int i = 0; i < N;)
			{
				BigInteger a = new BigInteger(rd.Next());
				BigInteger b = new BigInteger(rd.Next());

				BigInteger c = a * b - 1;
				if (seenBefore.ContainsKey(c)) continue;
				seenBefore.Add(c, true);
				bool prime = IsPrimeMillerRabin(c);
				if (!prime && rd.Next(0, (int)Math.Log(N)) != 0) continue;
				if (prime) count++;
				string sb = ConvertBigIntegerToBinary(c);
				while (sb.Length < val.Length) sb = "0," + sb;
				sw.WriteLine("{0},{1}", sb, prime ? "Prime" : "NotPrime");
				i++;
			}
			Console.WriteLine("Negative: {0}, Positive: {1}", N - count, count);
			sw.Close();
		}

		public static string ConvertBigIntegerToBinary(BigInteger d)
		{
			string retVal = "";

			while (d > 0)
			{
				retVal = ConvertDigitToBinary((int)(d % 10)) + "," + retVal;
				d /= 10;
			}

			if (retVal.EndsWith(",")) retVal = retVal.Substring(0, retVal.Length - 1);
			if (retVal.StartsWith(",")) retVal = retVal.Substring(1);

			return retVal;
		}

		public static string ConvertDigitToBinary(int d)
		{
			string retVal = "";

			while (d > 0)
			{
				retVal = (d % 2).ToString() + "," + retVal;
				d /= 2;
			}

			while (retVal.Length < 8)
			{
				retVal = "0" + "," + retVal;
			}

			if (retVal.EndsWith(",")) retVal = retVal.Substring(0, retVal.Length - 1);
			if (retVal.StartsWith(",")) retVal = retVal.Substring(1);

			return retVal;
		}

		public static bool IsPrimeMillerRabin(BigInteger n)
		{
			//It does not work well for smaller numbers, hence this check
			int SMALL_NUMBER = 1000;

			if (n <= SMALL_NUMBER)
			{
				return IsPrime(n);
			}

			int MAX_WITNESS = 500;
			for (long i = 2; i <= MAX_WITNESS; i++)
			{
				if (IsPrime(i) && Witness(i, n) == 1)
				{
					return false;
				}
			}

			return true;
		}

		public static BigInteger SqRtN(BigInteger N)
		{
			/*++
             *  Using Newton Raphson method we calculate the
             *  square root (N/g + g)/2
             */
			BigInteger rootN = N;
			int count = 0;
			int bitLength = 1;
			while (rootN / 2 != 0)
			{
				rootN /= 2;
				bitLength++;
			}
			bitLength = (bitLength + 1) / 2;
			rootN = N >> bitLength;

			BigInteger lastRoot = BigInteger.Zero;
			do
			{
				if (lastRoot > rootN)
				{
					if (count++ > 1000)                   // Work around for the bug where it gets into an infinite loop
					{
						return rootN;
					}
				}
				lastRoot = rootN;
				rootN = (BigInteger.Divide(N, rootN) + rootN) >> 1;
			}
			while (!((rootN ^ lastRoot).ToString() == "0"));
			return rootN;
		}

		public static bool IsPrime(BigInteger n)
		{
			if (n <= 1)
			{
				return false;
			}

			if (n == 2)
			{
				return true;
			}

			if (n % 2 == 0)
			{
				return false;
			}

			for (int i = 3; i <= SqRtN(n) + 1; i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		private static int Witness(long a, BigInteger n)
		{
			BigInteger t, u;
			BigInteger prev, curr = 0;
			BigInteger i;
			BigInteger lln = n;

			u = n / 2;
			t = 1;
			while (u % 2 == 0)
			{
				u /= 2;
				t++;
			}

			prev = BigInteger.ModPow(a, u, n);
			for (i = 1; i <= t; i++)
			{
				curr = BigInteger.ModPow(prev, 2, lln);
				if ((curr == 1) && (prev != 1) && (prev != lln - 1)) return 1;
				prev = curr;
			}
			if (curr != 1) return 1;
			return 0;
		}
	}

	public class NumberData
	{
		[Column("0")]
		public float b0;
		[Column("1")]
		public float b1;
		[Column("2")]
		public float b2;
		[Column("3")]
		public float b3;
		[Column("4")]
		public float b4;
		[Column("5")]
		public float b5;
		[Column("6")]
		public float b6;
		[Column("7")]
		public float b7;
		[Column("8")]
		public float b8;
		[Column("9")]
		public float b9;
		[Column("10")]
		public float b10;
		[Column("11")]
		public float b11;
		[Column("12")]
		public float b12;
		[Column("13")]
		public float b13;
		[Column("14")]
		public float b14;
		[Column("15")]
		public float b15;
		[Column("16")]
		public float b16;
		[Column("17")]
		public float b17;
		[Column("18")]
		public float b18;
		[Column("19")]
		public float b19;
		[Column("20")]
		public float b20;
		[Column("21")]
		public float b21;
		[Column("22")]
		public float b22;
		[Column("23")]
		public float b23;
		[Column("24")]
		public float b24;
		[Column("25")]
		public float b25;
		[Column("26")]
		public float b26;
		[Column("27")]
		public float b27;
		[Column("28")]
		public float b28;
		[Column("29")]
		public float b29;
		[Column("30")]
		public float b30;
		[Column("31")]
		public float b31;
		[Column("32")]
		public float b32;
		[Column("33")]
		public float b33;
		[Column("34")]
		public float b34;
		[Column("35")]
		public float b35;
		[Column("36")]
		public float b36;
		[Column("37")]
		public float b37;
		[Column("38")]
		public float b38;
		[Column("39")]
		public float b39;
		[Column("40")]
		public float b40;
		[Column("41")]
		public float b41;
		[Column("42")]
		public float b42;
		[Column("43")]
		public float b43;
		[Column("44")]
		public float b44;
		[Column("45")]
		public float b45;
		[Column("46")]
		public float b46;
		[Column("47")]
		public float b47;
		[Column("48")]
		public float b48;
		[Column("49")]
		public float b49;
		[Column("50")]
		public float b50;
		[Column("51")]
		public float b51;
		[Column("52")]
		public float b52;
		[Column("53")]
		public float b53;
		[Column("54")]
		public float b54;
		[Column("55")]
		public float b55;
		[Column("56")]
		public float b56;
		[Column("57")]
		public float b57;
		[Column("58")]
		public float b58;
		[Column("59")]
		public float b59;
		[Column("60")]
		public float b60;
		[Column("61")]
		public float b61;
		[Column("62")]
		public float b62;
		[Column("63")]
		public float b63;
		[Column("64")]
		public float b64;
		[Column("65")]
		public float b65;
		[Column("66")]
		public float b66;
		[Column("67")]
		public float b67;
		[Column("68")]
		public float b68;
		[Column("69")]
		public float b69;
		[Column("70")]
		public float b70;
		[Column("71")]
		public float b71;
		[Column("72")]
		public float b72;
		[Column("73")]
		public float b73;
		[Column("74")]
		public float b74;
		[Column("75")]
		public float b75;
		[Column("76")]
		[ColumnName("Label")]
		public string Label;
	}

	public class NumberPrediction
	{
		[ColumnName("PredictedLabel")]
		public string PredictedLabel;
	}
}
