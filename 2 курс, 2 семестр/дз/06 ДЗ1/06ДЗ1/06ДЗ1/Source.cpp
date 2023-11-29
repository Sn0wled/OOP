#include <iostream>
#include "complex.h"

using namespace std;

int main() {
	// ����������� �� ����������
	complex a;
	cout << "a: ";
	a.show(); // a: Re = 0, Im = 0
	// ����������� ����������
	complex b(4);
	cout << "b: ";
	b.show(); // b: Re = 4, Im = 0
	// ����������� ��������������
	complex c(5, 10);
	cout << "c: ";
	c.show(); // c: Re = 5, Im = 10
	// �������� ������������
	a = c;
	cout << "a: ";
	a.show(); // a: Re = 5, Im = 10
}
