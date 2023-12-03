#include <iostream>
#include "ddict.cpp"
#include <string>
#include <vector>

using namespace std;


int main() {
	ddict<int> a, b;
	for (int i = 0; i < 10; i++) {
		a.add(to_string(i), i);
	}
	for (int i = 5; i < 15; i++) {
		b.add(to_string(i), i);
	}
	cout << a << endl << b << endl;
	cout << a + b << endl;
	cout << a - b << endl;
}


