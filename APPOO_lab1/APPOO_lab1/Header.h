#include <iostream>
using namespace std;
class Header
{
private:
	int real;
	int img;
public:
	Header() :real(0), img(0) {}
	Header(int real, int img) :real(real), img(img) {}
	Header(const Header &a) :real(a.real), img(a.img) {}
	~Header() {
		real = 0;
		img = 0;
	}
	friend ostream &operator << (ostream &os, const Header &a) {
		return os << a.real << " + " << a.img << "i";
	}
	friend istream &operator >> (istream &is, Header &a) {
		return is >> a.real >> a.img;
	}

	bool operator < (Header &a) const {
		if (sqrt((real*real)+(img*img)) < sqrt((a.real*a.real) + (a.img*a.img))) return true;
		return false;
	}
	bool operator > (Header &a) const {
		if (sqrt((real*real) + (img*img)) > sqrt((a.real*a.real) + (a.img*a.img))) return true;
		return false;
	}
	Header &operator = (const Header &a) {
		real = a.real; img = a.img;
		return *this;
	}
	int getImg() const { return img; }
	int getReal() const { return real; }
};