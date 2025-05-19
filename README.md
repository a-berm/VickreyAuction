# Vickrey Auction

A Vickrey auction is a type of sealed-bid auction where the highest bidder wins as long as its bid meets or exceeds the reserve price, but pays the price offered by the highest bid of a non winner (which should meets or exceeds the reserve price as well), if no such bid exists, the reserve price is used. This project implements the core mechanics of a Vickrey auction as a kata, designed to practice clean code principles and unit tests.

---

## 🛠️ Tech Stack

- **Language**: C#
- **Framework**: .NET 8
- **Testing**: xUnit
- **Project type**: Console app

---

## 🚀 Getting Started

### Prerequisites

- .NET 8.0+
- Visual Studio Code or Visual Studio

### Clone the Repository

```bash
git clone https://github.com/a-berm/VickreyAuction.git
cd VickreyAuction/VickreyAuctionKata
```

### Run the Project

```bash
dotnet run
```

---

## 🧪 Running Tests

### Run All Tests

```bash
cd VickreyAuction/VickreyAuctionKata.Tests
dotnet test
```

---

## 📚 Additional Information and Bonus

- **Edge Case Handling**: In cases where two bidders have the same highest bid, the first bidder is considered the winner.
- **Extensibility**: The codebase is designed with open/closed principle in mind, making it easy to extend with custom auction logic.

---

## 📝 License

This project is open source and available under the **MIT License**.
