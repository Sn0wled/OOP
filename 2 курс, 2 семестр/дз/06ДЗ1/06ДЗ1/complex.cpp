#include <iostream>
#include "complex.h"

complex::complex() : _re(0), _im(0) {}
complex::complex(double re, double im) : _re(re), _im(im) {}
complex::complex(double re) : _re(re), _im(0) {}
complex::complex(const complex& a) : _re(a._re), _im(a._im) {}

complex& complex::operator=(complex a) {
	_re = a._re;
	_im = a._im;
	return *this;
}

complex::operator int() {
	return (int)_re;
}

complex::operator double() {
	return _re;
}

complex::operator char() {
	return (char)_re;
}

complex complex::operator+(complex a) {
	a._re += _re;
	a._im += _im;
	return a;
}

complex complex::operator-(complex a) {
	a._re = _re - a._re;
	a._im = _im - a._im;
	return a;
}

complex complex::operator*(complex a) {
	double re = _re * a._re - _im * a._im;
	double im = _re * a._im + _im * a._re;
	return complex(re, im);
}

complex complex::operator/(complex a) {
	complex temp;
	double divider = (a._re * a._re + a._im * a._im);
	temp._re = (_re * a._re + _im * a._im) / divider;
	temp._im = (a._re * _im - _re * a._im) / divider;
	return temp;
}

complex complex::operator%(complex a) {
	complex temp(*this);
	while (temp > complex(0))
	{
		temp = temp - a;
	}
	return temp;
}

complex operator+(int a, complex b) {
	return complex(a + b._re, b._im);
}

complex operator-(int a, complex b) {
	return complex(a - b._re, -b._im);
}

complex operator*(int a, complex b) {
	return complex(a * b._re, a * b._im);
}

complex operator/(int a, complex b) {
	return complex(a) / b;
}

complex operator%(int a, complex b) {
	return complex(a) % b;
}

complex operator+(double a, complex b) {
	return complex(a + b._re, b._im);
}

complex operator-(double a, complex b) {
	return complex(a - b._re, -b._im);
}

complex operator*(double a, complex b) {
	return complex(a * b._re, a * b._im);
}

complex operator/(double a, complex b) {
	return complex(a) / b;
}

complex operator%(double a, complex b) {
	return complex(a) % b;
}

complex complex::operator-() {
	return complex(-_re, -_im);
}

complex& complex::operator--() {
	--_re;
	return *this;
}

complex& complex::operator--(int) {
	complex temp = *this;
	_re--;
	return temp;
}

complex& complex::operator++() {
	++_re;
	return *this;
}

complex& complex::operator++(int) {
	complex temp = *this;
	_re++;
	return temp;
}

int complex::operator<(complex a) {
	if (_re < a._re && _im < a._im) return 1;
	return 0;
}

int complex::operator<=(complex a) {
	if (_re <= a._re && _im <= a._im) return 1;
	return 0;
}

int complex::operator>(complex a) {
	if (_re > a._re && _im > a._im) return 1;
	return 0;
}

int complex::operator>=(complex a) {
	if (_re >= a._re && _im >= a._im) return 1;
	return 0;
}

int complex::operator==(complex a) {
	if (_re == a._re && _im == a._im) return 1;
	return 0;
}

int complex::operator!=(complex a) {
	if (_re != a._re || _im != a._im) return 1;
	return 0;
}

std::ostream& operator<< (std::ostream& os, complex& c) {
	return os << "Re = " << c._re << ", Im = " << c._im;
}

int operator<(int a, complex b) {
	return complex(a) < b;
}
int operator<=(int a, complex b) {
	return complex(a) <= b;
}
int operator>(int a, complex b) {
	return complex(a) > b;
}
int operator>=(int a, complex b) {
	return complex(a) >= b;
}
int operator==(int a, complex b) {
	return complex(a) == b;
}
int operator!=(int a, complex b) {
	return complex(a) != b;
}

int operator<(double a, complex b) {
	return complex(a) < b;
}
int operator<=(double a, complex b) {
	return complex(a) <= b;
}
int operator>(double a, complex b) {
	return complex(a) > b;
}
int operator>=(double a, complex b) {
	return complex(a) >= b;
}
int operator==(double a, complex b) {
	return complex(a) == b;
}
int operator!=(double a, complex b) {
	return complex(a) != b;
}

double complex::operator[](int n) {
	if (n % 2 == 0) return _re;
	return _im;
}
void complex::set_re(double re) {
	_re = re;
}
void complex::set_im(double im) {
	_im = im;
}
void complex::set(double re, double im) {
	_re = re;
	_im = im;
}
int complex::re() {
	return _re;
}
int complex::im() {
	return _im;
}