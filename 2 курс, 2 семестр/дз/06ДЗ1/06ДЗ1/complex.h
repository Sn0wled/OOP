#pragma once
#include <iostream>

class complex {
	double _re, _im;
public:
	complex();
	complex(double re, double im);
	complex(double re);
	complex(const complex& a);
	complex& operator=(complex a);
	operator int();
	operator double();
	operator char();
	complex operator+(complex a);
	complex operator-(complex a);
	complex operator*(complex a);
	complex operator/(complex a);
	complex operator%(complex a);
	friend complex operator+(int a, complex b);
	friend complex operator-(int a, complex b);
	friend complex operator*(int a, complex b);
	friend complex operator/(int a, complex b);
	friend complex operator%(int a, complex b);
	friend complex operator+(double a, complex b);
	friend complex operator-(double a, complex b);
	friend complex operator*(double a, complex b);
	friend complex operator/(double a, complex b);
	friend complex operator%(double a, complex b);
	complex operator-();
	complex& operator--();
	complex& operator--(int);
	complex& operator++();
	complex& operator++(int);
	int operator<(complex a);
	int operator<=(complex a);
	int operator>(complex a);
	int operator>=(complex a);
	int operator==(complex a);
	int operator!=(complex a);
	friend int operator<(int a, complex b);
	friend int operator<=(int a, complex b);
	friend int operator>(int a, complex b);
	friend int operator>=(int a, complex b);
	friend int operator==(int a, complex b);
	friend int operator!=(int a, complex b);
	friend int operator<(double a, complex b);
	friend int operator<=(double a, complex b);
	friend int operator>(double a, complex b);
	friend int operator>=(double a, complex b);
	friend int operator==(double a, complex b);
	friend int operator!=(double a, complex b);
	friend std::ostream& operator<< (std::ostream&, complex&);
	double operator[](int n);
	void set_re(double re);
	void set_im(double im);
	void set(double re, double im);
	int re();
	int im();
};

