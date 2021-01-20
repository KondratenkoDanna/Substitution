#include <iostream>						// Построение таблицы инверсиЙ подстановки по данно подстановке
#include <vector>;						// и построение подстановка по ее таблице инверсий
using namespace std;

vector<int> InversionTable( int n, vector<int> p, vector<int> t)
{
	for (int i = 0; i < n; ++i)
		for (int j = 0; j < i; ++j)
			if (p[i] < p[j]) t[p[i] - 1]++;

	return t;
}

vector<int> Substitution(int n, vector<int> P, vector<int> t)
{
	int cur = 1;
	for (const auto& k : t)
	{
		int j = 0;
		for (int i = 0; i < n; ++i)
			if (P[i] == 0)
				if (j == k)
				{
					P[i] = cur;
					break;
				}
				else j++;
		cur++;
	}

	return P;
}

int main()
{
	int n;
	cout << "Enter the size: ";
	cin >> n;

	vector<int> p(n), t(n), P(n);

	cout << "Enter the substitution: ";
	for (int i = 0; i < n; ++i)
		cin >> p[i];

	t = InversionTable(n, p, t);
	P = Substitution(n, P, t);

	cout << "Inversion Table: ";
	for (int i : t) cout << i << " "; 
	cout << endl << "Substitution: ";
	for (int i : P) cout << i << " ";
}

